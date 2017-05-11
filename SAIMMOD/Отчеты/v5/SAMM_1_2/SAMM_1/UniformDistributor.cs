using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMM_1
{
    class UniformDistributor : SequenceProducer
    {
        private List<double> lst;
        TempCofficients tc;
        double a,b;
        public UniformDistributor(int _a, int _m, double _R0)
        {
            LehmerProducer lp = new LehmerProducer(_a, _m, _R0);
            lst = lp.ProvideSequence();
            tc = new TempCofficients(DistrMode.Uniform);
            tc.ShowDialog();
            a = tc.Value1;
            b = tc.Value2;
        }

        public override List<double> ProvideSequence()
        {
            List<double> rsq = new List<double>();
            foreach (double tmp in lst)
            {
                rsq.Add(a+(b-a)*tmp);
            }
            return rsq;
        }

    }
}
