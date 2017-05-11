using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3
{
    class State: Object
    {
        public int T { get; set; }

        public int N { get; set; }

        public int K1 { get; set; }

        public int K2 { get; set; }

        public State()
        {
            T = 2;
            N = 0;
            K1 = 0;
            K2 = 0;
        }

        public State(string state)
        {
            setState(state);
        }

        public override string ToString()
        {
            return T.ToString() + N.ToString() + K1.ToString() + K2.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj.ToString() == this.ToString();
        }

        public void setState(string state)
        {
            T = Int32.Parse(state.Substring(0, 1));
            N = Int32.Parse(state.Substring(1, 1));
            K1 = Int32.Parse(state.Substring(2, 1));
            K2 = Int32.Parse(state.Substring(3, 1));
        }

        public override int GetHashCode()
        {
            return Int32.Parse(ToString());
        }
    }
}
