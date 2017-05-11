'use strict';

function sum(array) {
  return array.reduce(function (a, b) {
    return a + b;
  }, 0);
}

function average(array) {
  return sum(array) / array.length;
}

// Generator

var generator = (function () {

  var x = 7,
      a = 15,
      c = 3,
      n = 32,
      i = 100 * 20,
      // i = 20,
      m = Math.pow(2, n);

  return {
    original: original,
    exponential: exponential,
    uniform: uniform,
    gaussian: gaussian
  };

  ////////

  function original() {
    return pickRand(seq());
  }

  function exponential(lambda) {
    return pickRand(exponentialDist(seq(), lambda));
  }

  function uniform(a, b) {
    return pickRand(uniformDist(seq(), a, b));
  }

  function gaussian(mean, variance) {
    return pickRand(gaussianDist(seq(), mean, variance, 1));
  }

  ////////

  function seq() {
    var originalSequenceClean = originalDistClean(x, i);
    var originalSequence = originalDistNormalize(originalSequenceClean);
    return originalSequence;
  }

  function originalDistClean(xStart, k) {
    var seq = [xStart];
    for (var i = 0; i < k; i++) {
      seq.push((a * seq[i] + c) % m);
    }
    return seq;
  }

  function originalDistNormalize(seq) {
    return seq.map(function (x) {
      return x / m;
    });
  }

  function exponentialDist(sequence, lambda) {
    return sequence.map(function (r) {
      return (-1 / lambda) * log10(r);
    });
  }

  function uniformDist(sequence, a, b) {
    return sequence.map(function (r) {
      return a + (b - a) * r;
    });
  }

  function gaussianDist(sequence, mean, variance, n) {
    return sequence.map(function (r) {
      var sumRands = sum(pickRands(sequence, n));
      return mean + variance * Math.sqrt(12 / n) * (sumRands - n / 2);
    });
  }

  ////////

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

}());


// Timeline

var timeline = (function () {



  return {
    run: run
  };

  function run(times, generate) {

    var queued = [];
    var processed = 0;
    var systemTimeInc = 0.5;
    var isInitial = true;

    var system = {
      time: 0,
      serveFinish: 0,
      serveStart: 0
    };

    var statistics = {
      queue: [],
      wait: []
    };

    function iteration (generate) {

      statistics.queue.push(queued.length);

      system.time += systemTimeInc;

      if (system.time > system.serveFinish) {

        if (queued.length > 0) {

          do {
            system.serveStart = system.serveFinish;
            system.serveFinish = system.serveStart + generate();

            if (system.time > system.serveFinish) {

              var startTime = queued.shift();
              processed += 1;

              statistics.wait.push(system.serveStart - startTime);

            } else {

              queued.push(system.time);
              break;
            }
          } while(queued.length > 0);

        } else {

          if (!isInitial) {
            statistics.wait.push(0);
            processed += 1;
          } else {
            isInitial = false;
          }

          system.serveStart = system.time;
          system.serveFinish = system.serveStart + generate();

        }

      } else {

        queued.push(system.time);

      }

    }

    for (var j = 0; j < times; j++) {
      iteration(generate);
    }

    console.log('--------------------------------------------------');
    console.log('Processed', processed);
    console.log('Average queue length', average(statistics.queue));
    console.log('Average wait time', average(statistics.wait));
    console.log('Statistics', statistics);
  }

}());



function task1() {
  var number = generator.exponential(2.5);
  // console.log(number);
  return number;
}

function task2() {
  var number = generator.uniform(0.2, 0.6);
  // console.log(number);
  return number;
}

function task3() {
  var number = generator.gaussian(0.4, 0.1);
  return number;
}

var iterations = 1000;

timeline.run(iterations, task1);
timeline.run(iterations, task2);
timeline.run(iterations, task3);













