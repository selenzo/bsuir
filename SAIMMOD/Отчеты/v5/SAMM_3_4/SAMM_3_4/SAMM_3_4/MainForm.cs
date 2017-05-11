using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SAMM_3_4
{
    public partial class MainForm : Form
    {
        Random rnd;
        const int numtacts = 100000;
        List<Label> lbs = new List<Label>();
        public MainForm()
        {
            InitializeComponent();
            rnd = new Random();
            #region lbsadd
            lbs.Add(label5);
            lbs.Add(label6);
            lbs.Add(label7);
            lbs.Add(label8);
            lbs.Add(label9);
            lbs.Add(label10);
            lbs.Add(label11);
            lbs.Add(label12);
            lbs.Add(label13);
            lbs.Add(label14);
            lbs.Add(label15);
            lbs.Add(label16);
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] prob = new int[13];
            QueueSystem qs = new QueueSystem(Double.Parse(textBox1.Text), Double.Parse(textBox2.Text));
           // QueueSystem qs = new QueueSystem(0.75,0.6);
            int[] firstValue = new int[4] {2, 0, 0, 0 };
            int[] nv = qs.Tact(firstValue);
            double MeanQLen=0,MeanTP=0;
            StreamWriter sw = new StreamWriter("1.csv");
            sw.WriteLine(Convert.ToString(firstValue[0]) + Convert.ToString(firstValue[1]) + Convert.ToString(firstValue[2]) + Convert.ToString(firstValue[3]));
            sw.WriteLine(Convert.ToString(nv[0]) + Convert.ToString(nv[1]) + Convert.ToString(nv[2]) + Convert.ToString(nv[3]));
            for (int i = 0; i <= numtacts; i++)
            {
                int t = nv[0];
                nv = qs.Tact(nv);
                if ((nv[0] == 2) && (t == 1)) MeanTP++;
                MeanQLen += nv[1];
                string s = Convert.ToString(nv[0]) + Convert.ToString(nv[1]) + Convert.ToString(nv[2]) + Convert.ToString(nv[3]);
                switch (s)
                {
                    case "2000":
                        prob[0]++;
                        break;
                    case "1000":
                        prob[1]++;
                        break;
                    case "2010":
                        prob[2]++;
                        break;
                    case "1010":
                        prob[3]++;
                        break;
                    case "2011":
                        prob[4]++;
                        break;
                    case "1001":
                        prob[5]++;
                        break;
                    case "1011":
                        prob[6]++;
                        break;
                    case "2111":
                        prob[7]++;
                        break;
                    case "1111":
                        prob[8]++;
                        break;
                    case "2211":
                        prob[9]++;
                        break;
                    case "1211":
                        prob[10]++;
                        break;
                    case "0211":
                        prob[11]++;
                        break;
                    default:
                        prob[12]++;
                        break;
                }
                sw.WriteLine(Convert.ToString(nv[0]) + Convert.ToString(nv[1]) + Convert.ToString(nv[2]) + Convert.ToString(nv[3]));
            }
            for (int j =0;j<=11;j++)
            {
                lbs[j].Text = Convert.ToString(j + 1) + " | " + Convert.ToString((double)prob[j] / numtacts);
            }
            sw.Close();
            MeanTP -= nv[1];
            MeanTP -= nv[2];
            MeanTP -= nv[3];
            label3.Text = "A="+Convert.ToString(MeanTP / numtacts);
            label4.Text ="Lоч="+Convert.ToString(MeanQLen / numtacts);
        }

    }
}
