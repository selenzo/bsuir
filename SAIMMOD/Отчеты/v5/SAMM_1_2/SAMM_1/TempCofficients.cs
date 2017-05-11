using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAMM_1
{
    public enum DistrMode
    {
        Uniform,
        Exponential,
        Gauss,
        Gamma,
        Triangular
    }
    public partial class TempCofficients : Form
    {
        public double Value1 { get { return Convert.ToDouble(textBox1.Text); } }
        public double Value2 { get { return Convert.ToDouble(textBox2.Text); } }
        public TempCofficients(DistrMode dm)
        {
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
            if (dm == DistrMode.Exponential)
            {
                label2.Visible = false;
                textBox2.Visible = false;
                label1.Text = "Введите коэффициент λ";
            }
            else if (dm == DistrMode.Uniform)
            {
                label1.Text = "Введите коэффициент a";
                label2.Text = "Введите коэффициент b";
            }
            else if (dm == DistrMode.Gamma)
            {
                label1.Text = "Введите коэффициент η";
                label2.Text = "Введите коэффициент λ";
            }
            else if (dm == DistrMode.Gauss)
            {
                label1.Text = "Введите коэффициент m";
                label2.Text = "Введите коэффициент σ";
            }

        }
    }
}
