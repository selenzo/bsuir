using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.Linq;


namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private double[] randArray;



        private void calculate_button_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                GaussDistribution();

            else if (comboBox1.SelectedIndex == 1)
                ExponentialDistribution();

            else if (comboBox1.SelectedIndex == 2)
                GammaDistribution();

        }

        // Гауссовское распределение
        private void GaussDistribution()
        {
            LehmerRandom rand = new LehmerRandom(ulong.Parse(textBox_a.Text), ulong.Parse(textBox_m.Text), ulong.Parse(textBox_R0.Text));
            int N = int.Parse(textBox5.Text);          // Количество генерируемых чисел
            double m = double.Parse(textBox1.Text);    // Мат. ожидание
            double sko = double.Parse(textBox2.Text);  // СКО
            int n = int.Parse(textBox3.Text);          // Число суммируемых равномерно распределённых чисел

            randArray = new double[N];
            for (int i = 0; i < N; i++)
            {
                double tmp = 0;
                for (int j = 0; j < n; j++)
                    tmp += rand.Next();

                randArray[i] = m + sko*Math.Sqrt(12.0/n)*(tmp - (double) n/2);
            }

            CalculateStatValues();
            DrawHistogram();
        }


        // Экспоненциальное распределение
        private void ExponentialDistribution()
        {
            LehmerRandom rand = new LehmerRandom(ulong.Parse(textBox_a.Text), ulong.Parse(textBox_m.Text), ulong.Parse(textBox_R0.Text));
            int N = int.Parse(textBox5.Text);          // Количество генерируемых чисел
            double λ = double.Parse(textBox1.Text);    // Параметр экспоненциального распределения

            randArray = new double[N];
            for (int i = 0; i < N; i++)
                randArray[i] = - Math.Log(rand.Next()) / λ;

            CalculateStatValues();
            DrawHistogram();
                    }

        // Гамма-распределение
        private void GammaDistribution()
        {
            LehmerRandom rand = new LehmerRandom(ulong.Parse(textBox_a.Text), ulong.Parse(textBox_m.Text), ulong.Parse(textBox_R0.Text));
            int N = int.Parse(textBox5.Text);          // Количество генерируемых чисел
            int η = int.Parse(textBox1.Text);
            double λ = double.Parse(textBox2.Text);

            randArray = new double[N];
            for (int i = 0; i < N; i++)
            {
                double tmp = 1;
                for (int j = 0; j < η; j++)
                    tmp *= rand.Next();

                randArray[i] = -Math.Log(tmp) / λ;
            }

            CalculateStatValues();
            DrawHistogram();

        }

        // Вывод сгенерированных чисел в текстовый файл
        private void show_button_Click(object sender, EventArgs e)
        {
            if (randArray == null) return;
            StreamWriter sw = new StreamWriter("random.txt");
            for (int i = 0; i < randArray.Length; i++)
                sw.WriteLine(randArray[i].ToString(CultureInfo.InvariantCulture));
            sw.Close();

            if (File.Exists("random.txt")) Process.Start("random.txt");
        }

        // Вычисление математического ожидания, дисперсии и СКО
        private void CalculateStatValues()
        {
            double Mx = randArray.Sum() / randArray.Length;
            textBox_Mx.Text = Mx.ToString("0.#####");

            double Dx = randArray.Sum(t => (t - Mx) * (t - Mx)) / (randArray.Length - 1);
            textBox_Dx.Text = Dx.ToString("0.#####");

            textBox_sko.Text = (Math.Sqrt(Dx)).ToString("0.#####");
        }

        // Построить гистограмму
        private void DrawHistogram()
        {
            List<double> numbers = new List<double>(randArray);
            numbers.Sort();

            const int intervalsCount = 20;
            double width = numbers.Last() - numbers.First();

            double widthOfInterval = width / intervalsCount;

            double[] heights = new double[intervalsCount];    // Высота столбцов гистограммы
            double[] X_values = new double[intervalsCount];  // Значение по оси x

            X_values[0] = 0.0245 * width + numbers.First();
            for (int i = 1; i < intervalsCount; i++)
                X_values[i] = X_values[i - 1] + widthOfInterval;

            double xLeft = numbers.First();           // Начало диаграммы по оси x
            double xRight = xLeft + widthOfInterval;  // Конец текущего интервала по оси x
            int j = 0;
            for (int i = 0; i < intervalsCount; i++)
            {
                while (j < numbers.Count && xLeft <= numbers[j] && xRight > numbers[j])
                {
                    heights[i] ++;
                    j++;
                }
                heights[i] /= numbers.Count;
                xLeft = xRight;
                xRight += widthOfInterval;
            }

            // Получим панель для рисования
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.XAxis.Title.Text = "Значение величины";
            pane.YAxis.Title.Text = "Частота попадания в интервал";
            pane.Title.Text = "";

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();

            BarItem bar = pane.AddBar("", X_values, heights, Color.Chocolate);

            // !!! Расстояния между кластерами (группами столбиков) гистограммы = 0.0
            // У нас в кластере только один столбик.
            pane.BarSettings.MinClusterGap = 0.0f;

            pane.XAxis.Scale.Min = numbers.First();
            pane.XAxis.Scale.Max = numbers.Last();
            pane.XAxis.Scale.AlignH = AlignH.Center;

            // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            zedGraphControl1.AxisChange();

            // Обновляем график
            zedGraphControl1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LehmerRandom rand = new LehmerRandom(ulong.Parse(textBox_a.Text), ulong.Parse(textBox_m.Text), ulong.Parse(textBox_R0.Text));
            int N = Int32.Parse(textBox5.Text);

            randArray = new double[N];

            for (int i = 0; i < N; i++)
                randArray[i] = rand.Next();

            CalculateStatValues();
            DrawHistogram();

            if (randArray == null) return;
            for (int i = 0; i < randArray.Length; i++)
                listBox1.Items.Add(randArray[i].ToString("0.#####"));
            var n = randArray.Length;
            var k = 0;

            for (var i = 0; i < n / 2; i++)
            {
                if (Math.Pow(randArray[i], 2) + Math.Pow(randArray[i + 1], 2) < 1)
                {
                    k++;
                }
            }

            var p = (double)2 * k / n;
            textBox6.Text = p.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label1.Text = "m = ";
                textBox1.Text = "5";
                label2.Text = "σ = ";
                textBox2.Text = "10";
                label3.Text = "n = ";
                textBox3.Text = "6";
                label2.Visible = true;
                textBox2.Visible = true;
                label3.Visible = true;
                textBox3.Visible = true;
            }

            if (comboBox1.SelectedIndex == 1)
            {
                label1.Text = "λ = "; textBox1.Text = "10";
                label2.Visible = false; textBox2.Visible = false;
                label3.Visible = false; textBox3.Visible = false;
            }

            if (comboBox1.SelectedIndex == 2)
            {
                label1.Text = "η = "; textBox1.Text = "18";
                label2.Text = "λ = "; textBox2.Text = "2";
                label2.Visible = true; textBox2.Visible = true;
                label3.Visible = false; textBox3.Visible = false;
            }
        }
    }
}
