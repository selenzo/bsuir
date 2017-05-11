using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMM_1
{
    class ExponentialDistributor : SequenceProducer
    {
        private List<double> lst;
        //StatisticsGeneration sg;
        TempCofficients tc;
        double lambda;
        public ExponentialDistributor(int _a, int _m, double _R0)
        {
            LehmerProducer lp = new LehmerProducer(_a, _m, _R0);
            lst = lp.ProvideSequence();
            tc = new TempCofficients(DistrMode.Exponential);
            tc.ShowDialog();
            lambda = tc.Value1;
        }

        public override List<double> ProvideSequence()
        {
            List<double> rsq = new List<double>();
            foreach (double tmp in lst)
            {
                rsq.Add(Math.Abs(Math.Log(tmp)/lambda));
            }
            return rsq;
        }

    }
}
