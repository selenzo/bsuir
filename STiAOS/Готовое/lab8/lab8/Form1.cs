using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lab8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void прцоессыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void блокнотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe");
        }

        private void калькуляторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void блокнотСТекстомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                Process.Start("notepad.exe", openFileDialog1.FileName);
            }
        }

        private void текущийПроцессToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.AppendText ("id:" + Process.GetCurrentProcess().Id + " procName:" + Process.GetCurrentProcess().ProcessName + " startTime:" + Process.GetCurrentProcess().StartTime + " memsize:" + Process.GetCurrentProcess().VirtualMemorySize / 8 / 1024 / 1024  + "mb");

        }

        private void блокнотToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process[] localByName = Process.GetProcessesByName("notepad");
            if(localByName.Length > 0)
            {
                Process proc = localByName[0];
                textBox1.AppendText("id:" + proc.Id + " procName:" + proc.ProcessName + " startTime:" + proc.StartTime + " memsize:" + proc.VirtualMemorySize / 8 / 1024 / 1024 + "mb");
            }

        }

        private void калькуляторToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process[] localByName = Process.GetProcessesByName("calc");
            if (localByName.Length > 0)
            {
                Process proc = localByName[0];
                textBox1.AppendText("id:" + proc.Id + " procName:" + proc.ProcessName + " startTime:" + proc.StartTime + " memsize:" + proc.VirtualMemorySize / 8 / 1024 / 1024 + "mb");
            }
        }
    }
}
