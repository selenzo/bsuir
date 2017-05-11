using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMM_1
{
    class GammaDistributor : SequenceProducer
    {
        private List<double> lst;
        TempCofficients tc;
        double eta, lambda;
        public GammaDistributor(int _a, int _m, double _R0)
        {
            LehmerProducer lp = new LehmerProducer(_a, _m, _R0);
            lst = lp.ProvideSequence();
            tc = new TempCofficients(DistrMode.Gamma);
            tc.ShowDialog();
            eta = tc.Value1;
            lambda = tc.Value2;
        }

        public override List<double> ProvideSequence()
        {
            List<double> rsq = new List<double>();
            Random rnd = new Random();
            for (int i = 0; i <= lst.Count-1; i++)
            {
                double R = 1;
                for (int j = 0; j <= Math.Floor(eta); j++)
                {
                    R *= lst[rnd.Next(lst.Count - 1)];
                }
                double tmp = -Math.Abs(Math.Log(R)/lambda);
                rsq.Add(tmp);
            }
            return rsq;
        }

    }
}
