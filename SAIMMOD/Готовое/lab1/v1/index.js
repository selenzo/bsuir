'use strict';


function getNodes(state) {
  var inp = state.split('').map(Number);
  var s = inp[0],
      c1 = inp[1],
      a = inp[2],
      c2 = inp[3];

  var nodes2 = [];

  console.log('Initial:', s, c1, a ,c2);

  if (c2 === 0) {

    nodes2.push(newNode(s, c1, a, 0)); // nothing

  } else if (c2 === 1) {

    nodes2.push(newNode(s, c1, a, 1, undefined, false)); // fail

    nodes2.push(newNode(s, c1, a, 0, undefined, true)); // done

  } else {
    return console.error('Bad c2');
  }

  nodes2.forEach(function (node) {
    if (node.a === 0) {

    } else if (node.a === 1) {

      if (node.c2 === 0) {
        node.c2 = 1;
        node.a = 0;
      }

    } else {
      return console.error('Bad a');
    }
  });

  var nodes1 = [];

  nodes2.forEach(function (node) {
    if (node.c1 === 0) {

      nodes1.push(newNode.apply(null, values(node))); // nothing

    } else if (node.c1 === 1) {

      nodes1.push(newNode(node.s, node.c1, node.a, node.c2, false, node.c2d)); // fail

      // done
      var nodeDone = newNode(node.s, node.c1, node.a, node.c2, true, node.c2d);

      if (nodeDone.a === 0) {

        if (nodeDone.c2 === 0) {

          nodes1.push(newNode(nodeDone.s, 0, 0, 1, true, nodeDone.c2d));

        } else if (nodeDone.c2 === 1) {

          nodes1.push(newNode(nodeDone.s, 0, 1, nodeDone.c2, true, nodeDone.c2d));

        }

      } else if (nodeDone.a === 1) {

        nodes1.push(nodeDone);

      }

    }
  });

  nodes1.forEach(function (node) {
    if (node.s === 0) {
      if (node.c1 === 0) {
        node.c1 = 1;
        node.s = 2;
      }
    } else if (node.s === 1) {
      if (node.c1 === 0) {
        node.c1 = 1;
        node.s = 2;
      } else if (node.c1 === 1) {
        node.s = 0;
      }
    } else if (node.s === 2) {
      node.s = 1;
    }
  });

  return arrayfy(nodes1);
}

function newNode(s, c1, a, c2, c1d, c2d) {
  return { s: s, c1: c1, a: a, c2: c2, c1d: c1d, c2d: c2d };
}

function arrayfy(nodes) {
  return nodes.map(function (node) {
    var newNode = {
      state: values(node, ['s', 'c1', 'a', 'c2']).join(''),
      c1d: node.c1d,
      c2d: node.c2d,
    };
    newNode.formula = getNodeFormula(node);
    delete newNode.c1d;
    delete newNode.c2d;
    return newNode;
  });
}

function getNodeFormula(node) {
  if (node.c1d === undefined && node.c2d === undefined) {
    return '1';
  } else if (node.c1d !== undefined && node.c2d === undefined) {
    return node.c1d ? '(1 - p1)' : 'p1';
  } else if (node.c1d === undefined && node.c2d !== undefined) {
    return node.c2d ? '(1 - p2)' : 'p2';
  } else if (node.c1d !== undefined && node.c2d !== undefined) {
    if (node.c1d && node.c2d) {
      return '(1 - p1) * (1 - p2)';
    } else if (node.c1d && !node.c2d) {
      return '(1 - p1) * p2';
    } else if (!node.c1d && node.c2d) {
      return 'p1 * (1 - p2)';
    } else if (!node.c1d && !node.c2d) {
      return 'p1 * p2';
    }
  }
}

function values(array, keys) {
  keys = keys || [];
  var result = [];
  Object.keys(array).forEach(function (key) {
    if (keys.length === 0 || keys.indexOf(key) !== -1) {
      result.push(array[key]);
    }
  });
  return result;
}

var initialState = '2000';
var p1 = 0.4, p2 = 0.8;

var map = {};

function buildTree(state) {
  var nodes = getNodes(state);
  if (!map.hasOwnProperty(state)) {
    map[state] = [];
    nodes.forEach(function (node) {
      map[state].push(node);
      buildTree(node.state);
    });
    map[state] = collapseNodes(map[state]);
  }
}

function collapseNodes(nodes) {
  var states = {};

  nodes.forEach(function (node) {
    states[node.state] = states[node.state] || [];
    states[node.state].push(node);
  });

  if (Object.keys(states).length === nodes.length) {
    return nodes;
  }

  Object.keys(states).forEach(function (state) {
    var repnodes = states[state];

    if (repnodes.length > 1) {

      var formula = repnodes.map(function (repnode) {
        return '(' + repnode.formula + ')';
      }).join(' + ');


      for (var i = 0, l = nodes.length; i < l; i++) {
        if (nodes[i].state === state) {
          delete nodes[i];
        }
      }

      nodes.push({
        state: state,
        formula: formula      });

    }
  });

  return nodes.filter(function () { return true; });
}



buildTree(initialState);

console.dir(map);


function flatten(array) {
  return array.reduce(function (array, item) {
    return array.concat(item);
  });
}

var networkNodes = Object.keys(map).map(function (state) {
  return {
    id: state,
    label: state
  };
});

var networkEdges = flatten(Object.keys(map).map(function (state) {
  var nodes = map[state];
  return nodes.map(function (node) {
    return {
      from: state,
      to: node.state,
      label: node.formula.replace(/p/g, 'π')
    };
  });
}));


var container = document.querySelector('#graph');

var network = new vis.Network(container, {
  nodes: networkNodes,
  edges: networkEdges
}, {
  width: '800px',
  height: '800px',
  edges: {
    arrowScaleFactor: 0.5,
    style: 'arrow',
    fontSize: 10
  },
  nodes: {
    fontSize: 12
  }
});


var incomingMap = {};

Object.keys(map).forEach(function (state) {
  var nodes = map[state];

  nodes.forEach(function (node) {
    incomingMap[node.state] = incomingMap[node.state] || [];
    incomingMap[node.state].push({
      state: state,
      formula: node.formula,
      result: substitute(node.formula)
    });
  });
});

function substitute(formula) {
  var f = formula;
  f = f.replace(/p1/g, p1);
  f = f.replace(/p2/g, p2);

  f = (new Function('', 'return ' + f))();

  f = f.toFixed(2);

  return f;
}

console.log(incomingMap);



function system(replace) {
  replace = replace || false;

  Object.keys(incomingMap).forEach(function (state, index) {
    var nodes = incomingMap[state];

    var eq = 'eq' + index + ':= p' + state + ' = ';

    eq += nodes.map(function (node) {
      var f = node.formula;
      if (replace) { f = substitute(f); }
      return '(' + f + ') * p' + node.state;
    }).join(' + ');

    eq += ';';

    console.log(eq);
  });
}

system(true);




