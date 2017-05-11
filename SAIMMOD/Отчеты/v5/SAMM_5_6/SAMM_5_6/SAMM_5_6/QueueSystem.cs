using System;
using System.Collections.Generic;

namespace SAMM_5_6
{
    class QueueSystem
    {
        private List<int> channels; //хранится время для освобождения всех каналов
        private List<int> timeDemands;
        double t, val;
        int numHours;
        Random rnd, rnd1, rnd2;
        int intens;
        double proctime, sum, demandpay, profit = 0;
        public QueueSystem(int numChannels, int _numHours, int _intens, double _proctime, double _sum, double _demandpay)
        {
            timeDemands = new List<int>();
            channels = new List<int>();
            rnd = new Random();
            rnd1 = new Random();
            rnd2 = new Random();
            for (int i = 0; i <= numChannels - 1; i++)
            {
                channels.Add(0);
            }
            numHours = _numHours;
            intens = _intens;
            proctime = _proctime;
            sum = _sum;
            demandpay = _demandpay;
        }

        private void addNewDemand()
        {
            //t = (float)rnd2.Next(1) / 1000*proctime;
            //val = (rnd1.Next(1000000) % 2 == 0) ? (proctime - t) : (proctime + t);
            val = Math.Abs(Math.Log((double)rnd2.Next(1000)/1000)*Math.Sqrt(proctime));
            //System.Windows.Forms.MessageBox.Show(Convert.ToString(val));
            int fr = channels.IndexOf(0);
            if (fr >= 0) //есть свободный канал
            {
                channels[fr] = (int)(val * 60);
            }
        }

        private void Minute(int order)
        {
            foreach (int k in channels)
            {
                if (k == 1) profit += demandpay;
            }
            for (int i = 0; i <= channels.Count - 1; i++)
                if (channels[i] != 0)
                    channels[i]--;
            if (timeDemands.Count != 0)
            {
                while ((timeDemands.Count>0)&&(timeDemands[0] == order))
                {
                    timeDemands.RemoveAt(0);
                    addNewDemand();
                }
            }
        }

        private void Hour()
        {
            for (int i = 0; i <= intens-1; i++)
            {
                timeDemands.Add(rnd.Next(60));
            }
            timeDemands.Sort();
            for (int j = 0; j <= 59; j++)
            {
                Minute(j);
            }

        }

        public double Operate()
        {
            for (int i = 0; i <= numHours - 1; i++)
            {
                Hour();
            }
            return (profit-numHours*channels.Count*sum);
        }
    }
}
