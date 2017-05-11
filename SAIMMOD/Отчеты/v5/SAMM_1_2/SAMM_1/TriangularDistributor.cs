using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMM_1
{
    class TriangularDistributor : SequenceProducer
    {
        private List<double> lst;
        TempCofficients tc;
        double a, b;
        public TriangularDistributor(int _a, int _m, double _R0)
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
            Random rnd = new Random();
            for (int i = 0; i <= lst.Count - 1; i++)
            {
                double R1 = lst[rnd.Next(lst.Count - 1)];
                double R2 = lst[rnd.Next(lst.Count - 1)];
                rsq.Add(a+(b-a)*Math.Max(R1,R2));
            }
            return rsq;
        }

    }
}
