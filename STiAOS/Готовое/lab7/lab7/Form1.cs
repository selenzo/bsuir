using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lab7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }

        private void читатьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string result = openFileDialog1.FileName;
            if (result != "openFileDialog1")
            {
                textBox1.Text = System.IO.File.ReadAllText(result);
            }
        }

        private void открытьИзображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
        }

        private void редакторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.ShowDialog();
        }
    }
}
