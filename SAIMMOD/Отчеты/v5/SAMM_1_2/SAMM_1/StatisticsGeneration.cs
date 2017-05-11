using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SAMM_1
{
    class StatisticsGeneration
    {
        private int period = 0;
        private double mx, Dx, sigmax, beg, end, interv;
        private string pathname = "rs.csv";
        List<double> randomSequence;
        StreamWriter sw;

        public double interval { get { return interv; } }
        public double _beg { get { return beg; } }
        public double _end { get { return end; } }

        public StatisticsGeneration(List<double> _randomSequence)
        {
            randomSequence = _randomSequence;
        }

        public double GetExpectation()
        {
            double t = 0;
            foreach (double i in randomSequence)
            {
                t += i;
            }
            mx = (double)t / randomSequence.Count;
            return mx;
        }

        public double GetDispersion()
        {
            double t = 0;
            foreach (double i in randomSequence)
            {
                t += Math.Pow((i-mx),2);
            }
            Dx = (double)t / randomSequence.Count;
            return Dx;
        }

        public double GetMeanSquareDeviation()
        {
            sigmax = Math.Sqrt(Dx);
            return sigmax;
        }

        public float[] GetDistr()
        {
            float[] distrib = new float[20];
            List<double> rstemp = new List<double>(randomSequence);
            rstemp.Sort();
            int c = 0;
            int index = 0;
            beg = rstemp[0];
            end = rstemp[rstemp.Count - 1];
            interv = (end - beg) / 20;
            for (int i = 0; i <= 19; i++)
            {
                while ((index<=rstemp.Count-1)&&(rstemp[index] <= beg+interv * (i + 1)))
                {
                    if (rstemp[index]>=beg)  c++;
                    index++;
                }
                distrib[i] = (float)c/randomSequence.Count;
                c = 0;
            }
            return distrib;
        }

        public int GetPeriod()
        {
            period = randomSequence.Count - randomSequence.IndexOf(randomSequence.Count - 1) - 1;
            return period;
        }

        public void ShowResults()
        {
            try
            {
                sw = new StreamWriter(pathname);
                foreach (double tmp in randomSequence)
                {
                    sw.WriteLine(Convert.ToString(tmp));
                }
                sw.Close();
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = pathname;
                p.Start();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Close Excel!!!");
            }
        }

        public double GetChecked()
        {
            int t = 0;
            for (int i = 0; i <= randomSequence.Count - 3; i++)
            {
                if (Math.Pow(randomSequence[i], 2) + Math.Pow(randomSequence[i+1], 2) <= 1)
                    t++;

            }
            return (double)t / randomSequence.Count;
        }

    }
}
