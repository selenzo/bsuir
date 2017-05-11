using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SAMM_1
{
    public partial class MainForm : Form
    {
        StatisticsGeneration sg;
        SequenceProducer lp;
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            switch (comboBox1.Text)
            {
                case "По алгоритму Лемера":
                    lp = new LehmerProducer(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToDouble(textBox3.Text));
                    break;
                case "Равномерное на интервале":
                    lp = new UniformDistributor(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToDouble(textBox3.Text));
                    break;
                case "Нормальное":
                    lp = new GaussDistributor(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToDouble(textBox3.Text));
                    break;
                case "Экспоненциальное":
                    lp = new ExponentialDistributor(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToDouble(textBox3.Text));
                    break;
                case "Гамма-распределение":
                    lp = new GammaDistributor(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToDouble(textBox3.Text));
                    break;
                case "Треугольное":
                    lp = new TriangularDistributor(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToDouble(textBox3.Text));
                    break;
                case "Симпсона":
                    lp = new SimpsonDistributor(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToDouble(textBox3.Text));
                    break;
                default:
                    break;
            }
            sg = new StatisticsGeneration(lp.ProvideSequence());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(sg.GetExpectation());
            textBox5.Text = Convert.ToString(sg.GetDispersion());
            textBox6.Text = Convert.ToString(sg.GetMeanSquareDeviation());
            textBox7.Text = Convert.ToString(sg.GetPeriod());
            textBox8.Text = Convert.ToString(sg.GetChecked());
            chart1.Series.Clear();
            Series DataSer = new Series();
            DataSer.Name = "Гистограмма";
            float[] distr = sg.GetDistr();
            for (int i = 0; i <= 19; i++)
            {
              //  MessageBox.Show(Convert.ToString(sg._beg));
                DataSer.Points.AddXY(Math.Round(sg._beg+sg.interval*(i+1),3), distr[i]);
            }
            chart1.ResetAutoValues();
            chart1.Series.Add(DataSer);
            sg.ShowResults();
        }
    }
}
