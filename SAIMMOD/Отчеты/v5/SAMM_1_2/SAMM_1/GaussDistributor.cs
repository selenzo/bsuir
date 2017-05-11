using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAMM_1
{
    class GaussDistributor:SequenceProducer
    {
        private List<double> lst;
        double expc, mdev;
        public GaussDistributor(int _a, int _m, double _R0)
        {
            LehmerProducer lp = new LehmerProducer(_a, _m, _R0);
            lst = lp.ProvideSequence();
            TempCofficients tc = new TempCofficients(DistrMode.Gauss);
            tc.ShowDialog();
            expc = tc.Value1;
            mdev = tc.Value2;
        }

        public override List<double> ProvideSequence()
        {
            List<double> rsq = new List<double>();
            Random rnd = new Random();
            for (int i = 0; i <= lst.Count-1; i++)
            {
                double R = 0;
                for (int j = 0; j <= 5; j++)
                {
                    R+=lst[rnd.Next(lst.Count-1)];
                }

                double tmp = expc + mdev * Math.Sqrt(2) * (R - 3);
                rsq.Add(tmp);
            }
            return rsq;
        }

    }
}
