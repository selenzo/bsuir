using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3
{
    class Immitation
    {
        protected int _iterationsCount;

        protected double _lastRandNumber;

        protected State _startState;

        protected State _state;

        protected LehmerRandom _random;

        protected Graph _graph;

        public Immitation(Graph graph, LehmerRandom random, State start)
        {
            _graph = graph;
            _random = random;
            _startState = start;

            reset();
        }

        public State CurrentState
        {
            get { return _state; }
        }

        public int IterationsCount
        {
            get { return _iterationsCount; }
        }

        public double LastRandom
        {
            get { return _lastRandNumber; }
        }

        public void reset()
        {
            _state = _startState;
            _iterationsCount = 0;
            _lastRandNumber = 0;
        }

        public void iteration()
        {
            IReadOnlyDictionary<State, double> transitions = _graph.getTransitions(_state);
            if (transitions.Count == 1)
            {
                _state = transitions.Keys.ToArray()[0];
                _lastRandNumber = 0;
            }
            else
            {
                _lastRandNumber = _random.Next();
                double L = 0;
                foreach (KeyValuePair<State, double> pair in transitions)
                {
                    if (_lastRandNumber > L && _lastRandNumber <= L + pair.Value)
                    {
                        _state = pair.Key;
                        break;
                    }
                    L += pair.Value;
                }
            }
            _iterationsCount++;
        }
    }
}
