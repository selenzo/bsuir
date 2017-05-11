using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMM_1
{
    class SimpsonDistributor:SequenceProducer
    {
        private List<double> lst;
        private List<double> lst2;
        TempCofficients tc;
        double a, b;
        public SimpsonDistributor(int _a, int _m, double _R0)
        {
            LehmerProducer lp = new LehmerProducer(_a, _m, _R0);
            lst = lp.ProvideSequence();
            tc = new TempCofficients(DistrMode.Uniform);
            tc.ShowDialog();
            a = tc.Value1;
            b = tc.Value2;
            lst2 = new List<double>();
            foreach (double tmp in lst)
            {
                lst2.Add(a / 2 + (b / 2 - a / 2) * tmp);
            }
        }

        public override List<double> ProvideSequence()
        {
            List<double> rsq = new List<double>();
            Random rnd = new Random();
            for (int i = 0; i <= lst.Count - 1; i++)
            {
                double R1 = lst2[rnd.Next(lst2.Count - 1)];
                double R2 = lst2[rnd.Next(lst2.Count - 1)];
                rsq.Add(R1+R2);
            }
            return rsq;
        }

    }
}
