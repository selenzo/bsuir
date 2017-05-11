(function () {

  function pickRand(array) {
    return array[Math.floor(array.length * Math.random())];
  }

  function pickRands(array, n) {
    var result = [];
    for (var i = 0; i < n; i++) {
      result.push(pickRand(array));
    }
    return result;
  }

  function log10(x) {
    return Math.log(x) / Math.LN10;
  }

  function mult(array) {
    return array.reduce(function (a, b) {
      return a * b;
    });
  }

  function sum(array) {
    return array.reduce(function (a, b) {
      return a + b;
    });
  }

  // ---------------------------------------------------------------------------

  function Sequence(containerSelector, canvasSelector) {
    this.vm = {};
    this.props();
    this.defaults();

    this.sequence = [];

    this.$el = $(containerSelector);
    this.$hist = $(canvasSelector);

    console.log('call');

    this.bindKO();
  };

  // override in children

  Sequence.prototype.props = function () {};
  Sequence.prototype.generate = function () {};
  Sequence.prototype.get = function () { return this.sequence; };

  Sequence.prototype.defaults = function (arguments) {
    this.vm.submit = function () { this.submit(); }.bind(this);
  };
  Sequence.prototype.submit = function () {
    this.sequence = this.generate();
    this.drawHist();
  };
  Sequence.prototype.bindKO = function () {
    console.log(this.vm, this.$el);
    ko.applyBindings(this.vm, this.$el.get(0));
  };
  Sequence.prototype.drawHist = function () {
    var segmentsCount = 20;
    var seq = this.sequence;

    var min = Math.min.apply(null, this.sequence),
        max = Math.max.apply(null, this.sequence),
        length = max - min;

    var segmentLength = length / segmentsCount;

    var map = {};

    seq.forEach(function (el) {
      if (el >= max || el < min) { return; }
      var segmentNumber = Math.ceil(el / segmentLength);
      map[segmentNumber] = (map[segmentNumber] + 1) || 1;
    });

    function sortNeg(a, b) { return a - b; }

    function values(obj) {
      return Object.keys(obj).sort(sortNeg).map(function (key) {
        return obj[key] / seq.length;
      });
    }

    function keys(obj) {
      return Object.keys(obj).sort(sortNeg).map(function (key) {
        return (segmentLength * key).toFixed(2);
      });
    }

    console.log(map);

    var ctx = this.$hist.get(0).getContext('2d');
    var data = {
      labels: keys(map),
      datasets: [{
        data: values(map)
      }]
    };

    var chart = new Chart(ctx).Bar(data, {
      // scaleOverride: true,
      // scaleSteps: 10,
      // scaleStepWidth: 0.1,
      // scaleStartValue: 0
    });
  };

  // ---------------------------------------------------------------------------

  function OriginalSequence() {
    Sequence.apply(this, arguments);
  }
  OriginalSequence.prototype = Object.create(Sequence.prototype);
  OriginalSequence.prototype.props = function () {
    this.vm = {
      x: ko.observable(7),
      a: ko.observable(15),
      c: ko.observable(3),
      n: ko.observable(32),
      i: ko.observable(2000)
    };
    this.vm.m = ko.computed(function () {
      return Math.pow(2, this.vm.n());
    }, this);
  };
  OriginalSequence.prototype.generate = function () {
    var sequence = [this.vm.x()];
    for (var i = 0; i < this.vm.i(); i++) {
      var x = (this.vm.a() * sequence[i] + this.vm.c()) % this.vm.m();
      sequence.push(x);
    }

    var msequence = sequence.map(function (x) {
      return x / this.vm.m();
    }, this);

    return msequence;
  };

  // ---------------------------------------------------------------------------

  var originalSequence = new OriginalSequence(
    '#original-dist', '#canvas-original'
  );
  originalSequence.submit();

  // ---------------------------------------------------------------------------

  function UniformDistSequence() {
    Sequence.apply(this, arguments);
    var args = Array.prototype.slice.call(arguments);
    this.originalSequence = args[args.length - 1];
  }
  UniformDistSequence.prototype = Object.create(Sequence.prototype);
  UniformDistSequence.prototype.constructor = UniformDistSequence;
  UniformDistSequence.prototype.props = function () {
    this.vm = {
      a: ko.observable(5),
      b: ko.observable(10)
    };
  };
  UniformDistSequence.prototype.generate = function () {
    return this.originalSequence.map(function (r) {
      return this.vm.a() + (this.vm.b() - this.vm.a()) * r;
    }, this);
  };

  var uniformDistSequence = new UniformDistSequence(
    '#uniform', '#graph-derivative', originalSequence.get()
  );

  // uniformDistSequence.submit();


}());
