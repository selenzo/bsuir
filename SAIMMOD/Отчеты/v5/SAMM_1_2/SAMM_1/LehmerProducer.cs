using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMM_1
{
    class LehmerProducer:SequenceProducer
    {
        int a, m;
        double R0;
        private List<double> randomsq = new List<double>();
        public LehmerProducer(int _a, int _m, double _R0)
        {
            a = _a;
            m = _m;
            R0 = _R0;
        }
        public override List<double> ProvideSequence()
        {
            double tmp;

            LehmerRandom lr = new LehmerRandom(a, m, R0);
            randomsq.Add(lr.Next());
            tmp = lr.Next();
            while (!randomsq.Contains(tmp))
            {
                randomsq.Add(tmp);
                tmp = lr.Next();
            }
            //randomsq.Add(tmp);
            return randomsq;

        }
    }
}
