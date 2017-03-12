using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lab6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // MessageBox.Show("Form load");
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mouse click!");
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
           // label1.Location = new Point(label1.Location.X + 10,10);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label2.Text = vScrollBar1.Value.ToString();
        }

        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            label3.Text = vScrollBar2.Value.ToString();
        }
    }
}
