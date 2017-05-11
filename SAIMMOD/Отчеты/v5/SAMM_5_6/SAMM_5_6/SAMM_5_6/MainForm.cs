using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace SAMM_5_6
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("1.csv");
            double[] values = new double[20];
            chart1.Series.Clear();
            System.Windows.Forms.DataVisualization.Charting.Series DataSer_1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            DataSer_1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            DataSer_1.Color = Color.Red;
            DataSer_1.Name = "";
            for (int i = 1; i <= 20; i++)
            {
                QueueSystem qs = new QueueSystem(i, 100,Int32.Parse(textBox1.Text),Double.Parse(textBox2.Text),Double.Parse(textBox3.Text),Double.Parse(textBox4.Text));
                values[i - 1] = qs.Operate();
                sw.WriteLine(Convert.ToString(i) + ';' + Convert.ToString(values[i - 1]));
                DataSer_1.Points.AddXY((double)i, values[i - 1]);
            }
            sw.Close();
            double max = values.Max();
            label1.Text = "Целесообразное количество каналов: " + Convert.ToString(values.ToList().IndexOf(max) + 1);
            label2.Text = "Максимальная прибыль: " + Convert.ToString(max) + " у.е.";
            chart1.ResetAutoValues();
            chart1.Series.Add(DataSer_1);


        }
    }
}
