using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace lab9
{
    public partial class Form1 : Form
    {
        private static Mutex mut = new Mutex();
        public static bool th = false;
        public static Thread th1, th2;
        public static string txt = " Какой-то текст в бегущей строке";

        public static void ThFunc()
        {
            mut.WaitOne();
            th = !th;
            Thread.Sleep(3000);
            mut.ReleaseMutex();
        }

        public Form1()
        {
            th1 = new Thread(new ThreadStart(ThFunc));
            th1.Start();
            th2 = new Thread(new ThreadStart(ThFunc));
            th2.Start();


            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = (th ? "Поток 1 управляет" : "Поток 2 управляет");
            string scrollText = label1.Text;
            if (th)
            {
                scrollText = scrollText.Substring(1, (scrollText.Length - 1)) + scrollText.Substring(0, 1);

            } else
            {
                scrollText = scrollText.Substring((scrollText.Length - 1), 1) + scrollText.Substring(0, (scrollText.Length - 1));
            }
            label1.Text = scrollText;

        }
    }
}
