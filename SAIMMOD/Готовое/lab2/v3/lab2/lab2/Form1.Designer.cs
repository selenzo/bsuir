namespace lab2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.calculate_button = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_sko = new System.Windows.Forms.TextBox();
            this.textBox_Dx = new System.Windows.Forms.TextBox();
            this.textBox_Mx = new System.Windows.Forms.TextBox();
            this.label_sko = new System.Windows.Forms.Label();
            this.labelDx = new System.Windows.Forms.Label();
            this.labelMx = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox_R0 = new System.Windows.Forms.TextBox();
            this.textBox_m = new System.Windows.Forms.TextBox();
            this.textBox_a = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            //
            // groupBox1
            //
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 189);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Распределение";
            //
            // comboBox1
            //
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Нормальное (гауссосвское)",
            "Экспоненциальное (показательное)",
            "Гамма-распределение"});
            this.comboBox1.Location = new System.Drawing.Point(7, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(190, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            //
            // zedGraphControl1
            //
            this.zedGraphControl1.BackColor = System.Drawing.SystemColors.Window;
            this.zedGraphControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.zedGraphControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.zedGraphControl1.IsEnableHPan = false;
            this.zedGraphControl1.IsEnableHZoom = false;
            this.zedGraphControl1.IsEnableVPan = false;
            this.zedGraphControl1.IsEnableVZoom = false;
            this.zedGraphControl1.IsShowContextMenu = false;
            this.zedGraphControl1.Location = new System.Drawing.Point(313, 14);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.SelectModifierKeys = System.Windows.Forms.Keys.D1;
            this.zedGraphControl1.Size = new System.Drawing.Size(527, 325);
            this.zedGraphControl1.TabIndex = 16;
            //
            // groupBox2
            //
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.calculate_button);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(13, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(202, 206);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры";
            //
            // textBox4
            //
            this.textBox4.Location = new System.Drawing.Point(72, 103);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 7;
            this.textBox4.Visible = false;
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            //
            // textBox3
            //
            this.textBox3.Location = new System.Drawing.Point(72, 76);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 5;
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            //
            // calculate_button
            //
            this.calculate_button.Location = new System.Drawing.Point(72, 127);
            this.calculate_button.Name = "calculate_button";
            this.calculate_button.Size = new System.Drawing.Size(94, 27);
            this.calculate_button.TabIndex = 17;
            this.calculate_button.Text = "Рассчитать";
            this.calculate_button.UseVisualStyleBackColor = true;
            this.calculate_button.Click += new System.EventHandler(this.calculate_button_Click);
            //
            // textBox2
            //
            this.textBox2.Location = new System.Drawing.Point(72, 50);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            //
            // textBox1
            //
            this.textBox1.Location = new System.Drawing.Point(72, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            //
            // groupBox3
            //
            this.groupBox3.Controls.Add(this.textBox_sko);
            this.groupBox3.Controls.Add(this.textBox_Dx);
            this.groupBox3.Controls.Add(this.textBox_Mx);
            this.groupBox3.Controls.Add(this.label_sko);
            this.groupBox3.Controls.Add(this.labelDx);
            this.groupBox3.Controls.Add(this.labelMx);
            this.groupBox3.Location = new System.Drawing.Point(313, 346);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(255, 102);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            //
            // textBox_sko
            //
            this.textBox_sko.Location = new System.Drawing.Point(45, 73);
            this.textBox_sko.Name = "textBox_sko";
            this.textBox_sko.ReadOnly = true;
            this.textBox_sko.Size = new System.Drawing.Size(185, 20);
            this.textBox_sko.TabIndex = 11;
            //
            // textBox_Dx
            //
            this.textBox_Dx.Location = new System.Drawing.Point(45, 47);
            this.textBox_Dx.Name = "textBox_Dx";
            this.textBox_Dx.ReadOnly = true;
            this.textBox_Dx.Size = new System.Drawing.Size(185, 20);
            this.textBox_Dx.TabIndex = 10;
            //
            // textBox_Mx
            //
            this.textBox_Mx.Location = new System.Drawing.Point(45, 21);
            this.textBox_Mx.Name = "textBox_Mx";
            this.textBox_Mx.ReadOnly = true;
            this.textBox_Mx.Size = new System.Drawing.Size(185, 20);
            this.textBox_Mx.TabIndex = 9;
            //
            // label_sko
            //
            this.label_sko.AutoSize = true;
            this.label_sko.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_sko.Location = new System.Drawing.Point(15, 73);
            this.label_sko.Name = "label_sko";
            this.label_sko.Size = new System.Drawing.Size(32, 17);
            this.label_sko.TabIndex = 8;
            this.label_sko.Text = "σ = ";
            //
            // labelDx
            //
            this.labelDx.AutoSize = true;
            this.labelDx.Location = new System.Drawing.Point(14, 52);
            this.labelDx.Name = "labelDx";
            this.labelDx.Size = new System.Drawing.Size(32, 13);
            this.labelDx.TabIndex = 7;
            this.labelDx.Text = "Dx = ";
            //
            // labelMx
            //
            this.labelMx.AutoSize = true;
            this.labelMx.Location = new System.Drawing.Point(14, 24);
            this.labelMx.Name = "labelMx";
            this.labelMx.Size = new System.Drawing.Size(33, 13);
            this.labelMx.TabIndex = 6;
            this.labelMx.Text = "Mx = ";
            //
            // groupBox4
            //
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.textBox5);
            this.groupBox4.Controls.Add(this.textBox_R0);
            this.groupBox4.Controls.Add(this.textBox_m);
            this.groupBox4.Controls.Add(this.textBox_a);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(203, 171);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Исходные данные алгоритма Лемера";
            //
            // button1
            //
            this.button1.Location = new System.Drawing.Point(73, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Рассчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            //
            // label8
            //
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "N = ";
            //
            // textBox5
            //
            this.textBox5.Location = new System.Drawing.Point(73, 111);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 6;
            this.textBox5.Text = "1000";
            //
            // textBox_R0
            //
            this.textBox_R0.Location = new System.Drawing.Point(73, 84);
            this.textBox_R0.Name = "textBox_R0";
            this.textBox_R0.Size = new System.Drawing.Size(100, 20);
            this.textBox_R0.TabIndex = 5;
            this.textBox_R0.Text = "1013904223";
            //
            // textBox_m
            //
            this.textBox_m.Location = new System.Drawing.Point(73, 58);
            this.textBox_m.Name = "textBox_m";
            this.textBox_m.Size = new System.Drawing.Size(100, 20);
            this.textBox_m.TabIndex = 4;
            this.textBox_m.Text = "4294967296";
            //
            // textBox_a
            //
            this.textBox_a.Location = new System.Drawing.Point(73, 32);
            this.textBox_a.Name = "textBox_a";
            this.textBox_a.Size = new System.Drawing.Size(100, 20);
            this.textBox_a.TabIndex = 3;
            this.textBox_a.Text = "1664525";
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "c = ";
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "m = ";
            //
            // label7
            //
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "a = ";
            //
            // listBox1
            //
            this.listBox1.BackColor = System.Drawing.SystemColors.Control;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(221, 14);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(85, 433);
            this.listBox1.TabIndex = 22;
            //
            // textBox6
            //
            this.textBox6.BackColor = System.Drawing.SystemColors.Control;
            this.textBox6.Location = new System.Drawing.Point(54, 22);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(185, 20);
            this.textBox6.TabIndex = 23;
            //
            // label9
            //
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "2K/N = ";
            //
            // groupBox5
            //
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.textBox6);
            this.groupBox5.Location = new System.Drawing.Point(576, 348);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(255, 99);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Проверка по косвенным признакам";
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 452);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ЛР2_САИММОД";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button calculate_button;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_sko;
        private System.Windows.Forms.TextBox textBox_Dx;
        private System.Windows.Forms.TextBox textBox_Mx;
        private System.Windows.Forms.Label label_sko;
        private System.Windows.Forms.Label labelDx;
        private System.Windows.Forms.Label labelMx;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox_R0;
        private System.Windows.Forms.TextBox textBox_m;
        private System.Windows.Forms.TextBox textBox_a;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}

