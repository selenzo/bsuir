using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3
{
    class Graph
    {
        protected State[] vertices;

        protected double[,] transitions = {
            {0.5 ,   0,   0,   0,   0,   0,   0.5, 0,   0,   0},
            {0.325,  0.175,   0,   0,   0,   0,   0.325,   0.175,   0,   0},
            {0,  0.275,   0.225,   0,   0,   0,   0,   0.275,   0.225,   0},
            {0,  0.275,   0.14625, 0.07875, 0,   0,   0,   0.17875, 0.14625, 0.175},
            {0,  0,   0,   0.275,   0.225,   0,   0,   0,   0.225,   0.275},
            {0,  0 ,  0.17875, 0.09625, 0.14625, 0.07875, 0,   0.17875, 0.14625, 0.175},

            {0,  0,   0,   0,   0,   0.225,   0,   0,   0.5, 0.275},
            {0,  0,   0,   0.275,   0.225,   0,   0,   0,   0.225,   0.275},
            {0,  0 ,  0.17875, 0.09625, 0.14625, 0.07875, 0,   0.17875, 0.14625, 0.175},
            {0,  0,   0,   0,   0, 0, 0,  0 ,  0,   1}

        };


        protected double[,] transitions2 = {
            {0.5,	0,	0,	0,	0,	0,	0.5,	0,	0,	0,	0},
            {0.3,	0.2,	0,	0,	0,	0,	0.3,	0.2,	0,	0,	0},
            {0,	0.3,	0.2,	0,	0,	0,	0,	0.3,	0.2,	0,	0},
            {0,	0.2,	0,	0.3,	0,	0,	0.3,	0.2,	0,	0,	0},
            {0,	0.12,	0.08,	0.18,	0.12,	0,	0.18,	0.24,	0.08,	0,	0},
            {0,	0,	0.12,	0,	0.18,	0.12,	0,	0.18,	0.24,	0.08,	0.08},
            {0,	0.2,	0,	0.3,	0,	0,	0.3,	0.2,	0,	0,	0},
            {0,	0.12,	0.08,	0.18,	0.12,	0,	0.18,	0.24,	0.08,	0,	0},
            {0,	0,	0.12,	0,	0.18,	0.12,	0,	0.18,	0.24,	0.08,	0.08},
            {0,	0,	0.3,	0,	0,	0,	0,	0,	0.3,	0.2,	0.2},
            {0,	0,	0,	0,	0,	0,	0,	0,	0.5,	0,	0.5}
        };

        public Graph()
        {
            string[] states = { "0000",	"0001", "0010", "0011", "0110", "0111", "1010", "1011", "1110","1111" };
            vertices = new State[states.Length];
            for (int i = 0; i < states.Length; i++)
            {
                vertices[i] = new State(states[i]);
            }
        }

        public IReadOnlyDictionary<State, double> getTransitions(State state)
        {
            IDictionary<State, double> states = new Dictionary<State, double>();
            int j = vertices.ToList().FindIndex(x => state.Equals(x));
            for (int i = 0; i < vertices.Length; i++)
            {
                if (transitions[j, i] != 0)
                {
                    states[vertices[i]] = transitions[j, i];
                }
            }
            return (IReadOnlyDictionary<State, double>) states;
        }

        public IReadOnlyList<string> getVertices()
        {
            return (IReadOnlyList<string>)vertices.ToList();
        }
    }
}
