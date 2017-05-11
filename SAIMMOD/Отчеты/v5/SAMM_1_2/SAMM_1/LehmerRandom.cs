using System;
using System.Collections.Generic;
using System.Text;

namespace SAMM_1
{
    class LehmerRandom
    {
        private int a, m;
        private double R0, Rc;

        public LehmerRandom(int _a, int _m, double _R0)
        {
            a = _a;
            m = _m;
            R0 = _R0;
            Rc = _R0;
        }

        public double Next()
        {
            double _R = a * R0 % m;
            Rc = a * R0 / m;
            R0 = _R;
            return Rc - Math.Floor(Rc);
        }
    }
}
