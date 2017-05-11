namespace Saimm2
{
	partial class Main
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.valL = new System.Windows.Forms.ListBox();
			this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.xTb = new System.Windows.Forms.TextBox();
			this.pTb = new System.Windows.Forms.TextBox();
			this.aTb = new System.Windows.Forms.TextBox();
			this.deltMathTb = new System.Windows.Forms.TextBox();
			this.cTb = new System.Windows.Forms.TextBox();
			this.dTb = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.MathTb = new System.Windows.Forms.TextBox();
			this.mLabel = new System.Windows.Forms.Label();
			this.computeBtn = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.dLabel = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.delMathLabel = new System.Windows.Forms.Label();
			this.NTb = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.mTb = new System.Windows.Forms.TextBox();
			this.methodsList = new System.Windows.Forms.ListBox();
			this.additionalParamsBox = new System.Windows.Forms.GroupBox();
			this.additionalParam2_Tb = new System.Windows.Forms.TextBox();
			this.additionalParam2_label = new System.Windows.Forms.Label();
			this.additionalParam1_Tb = new System.Windows.Forms.TextBox();
			this.additionalParam1_label = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.periodTb = new System.Windows.Forms.TextBox();
			this.aperiodTb = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
			this.additionalParamsBox.SuspendLayout();
			this.SuspendLayout();
			//
			// valL
			//
			this.valL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
			this.valL.FormattingEnabled = true;
			this.valL.Location = new System.Drawing.Point(186, 143);
			this.valL.Name = "valL";
			this.valL.Size = new System.Drawing.Size(180, 394);
			this.valL.TabIndex = 23;
			//
			// chart
			//
			this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
			chartArea1.Name = "ChartArea1";
			this.chart.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart.Legends.Add(legend1);
			this.chart.Location = new System.Drawing.Point(410, 332);
			this.chart.Name = "chart";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Гистограмма";
			this.chart.Series.Add(series1);
			this.chart.Size = new System.Drawing.Size(520, 205);
			this.chart.TabIndex = 29;
			this.chart.Text = "chart";
			//
			// xTb
			//
			this.xTb.Location = new System.Drawing.Point(54, 144);
			this.xTb.Name = "xTb";
			this.xTb.Size = new System.Drawing.Size(100, 20);
			this.xTb.TabIndex = 9;
			this.xTb.Text = "7";
			//
			// pTb
			//
			this.pTb.Location = new System.Drawing.Point(559, 221);
			this.pTb.Name = "pTb";
			this.pTb.ReadOnly = true;
			this.pTb.Size = new System.Drawing.Size(173, 20);
			this.pTb.TabIndex = 28;
			//
			// aTb
			//
			this.aTb.Location = new System.Drawing.Point(54, 170);
			this.aTb.Name = "aTb";
			this.aTb.Size = new System.Drawing.Size(100, 20);
			this.aTb.TabIndex = 10;
			this.aTb.Text = "5";
			//
			// deltMathTb
			//
			this.deltMathTb.Location = new System.Drawing.Point(559, 195);
			this.deltMathTb.Name = "deltMathTb";
			this.deltMathTb.ReadOnly = true;
			this.deltMathTb.Size = new System.Drawing.Size(173, 20);
			this.deltMathTb.TabIndex = 27;
			//
			// cTb
			//
			this.cTb.Location = new System.Drawing.Point(54, 196);
			this.cTb.Name = "cTb";
			this.cTb.Size = new System.Drawing.Size(100, 20);
			this.cTb.TabIndex = 11;
			this.cTb.Text = "3";
			//
			// dTb
			//
			this.dTb.Location = new System.Drawing.Point(559, 169);
			this.dTb.Name = "dTb";
			this.dTb.ReadOnly = true;
			this.dTb.Size = new System.Drawing.Size(173, 20);
			this.dTb.TabIndex = 26;
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(28, 147);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(20, 13);
			this.label1.TabIndex = 15;
			this.label1.Text = "X0";
			//
			// MathTb
			//
			this.MathTb.Location = new System.Drawing.Point(559, 143);
			this.MathTb.Name = "MathTb";
			this.MathTb.ReadOnly = true;
			this.MathTb.Size = new System.Drawing.Size(173, 20);
			this.MathTb.TabIndex = 25;
			//
			// mLabel
			//
			this.mLabel.AutoSize = true;
			this.mLabel.Location = new System.Drawing.Point(407, 146);
			this.mLabel.Name = "mLabel";
			this.mLabel.Size = new System.Drawing.Size(146, 13);
			this.mLabel.TabIndex = 12;
			this.mLabel.Text = "Математическое ожидание";
			//
			// computeBtn
			//
			this.computeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.computeBtn.Location = new System.Drawing.Point(31, 514);
			this.computeBtn.Name = "computeBtn";
			this.computeBtn.Size = new System.Drawing.Size(123, 23);
			this.computeBtn.TabIndex = 24;
			this.computeBtn.Text = "Сгенерировать";
			this.computeBtn.UseVisualStyleBackColor = true;
			this.computeBtn.Click += new System.EventHandler(this.computeBtn_Click);
			//
			// label2
			//
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(28, 173);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(13, 13);
			this.label2.TabIndex = 18;
			this.label2.Text = "a";
			//
			// dLabel
			//
			this.dLabel.AutoSize = true;
			this.dLabel.Location = new System.Drawing.Point(407, 172);
			this.dLabel.Name = "dLabel";
			this.dLabel.Size = new System.Drawing.Size(64, 13);
			this.dLabel.TabIndex = 14;
			this.dLabel.Text = "Дисперсия";
			//
			// label5
			//
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(28, 251);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(15, 13);
			this.label5.TabIndex = 21;
			this.label5.Text = "N";
			//
			// label3
			//
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(28, 199);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(13, 13);
			this.label3.TabIndex = 17;
			this.label3.Text = "c";
			//
			// label4
			//
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(28, 225);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(15, 13);
			this.label4.TabIndex = 22;
			this.label4.Text = "m";
			//
			// delMathLabel
			//
			this.delMathLabel.AutoSize = true;
			this.delMathLabel.Location = new System.Drawing.Point(407, 198);
			this.delMathLabel.Name = "delMathLabel";
			this.delMathLabel.Size = new System.Drawing.Size(29, 13);
			this.delMathLabel.TabIndex = 13;
			this.delMathLabel.Text = "СКО";
			//
			// NTb
			//
			this.NTb.Location = new System.Drawing.Point(54, 248);
			this.NTb.Name = "NTb";
			this.NTb.Size = new System.Drawing.Size(100, 20);
			this.NTb.TabIndex = 19;
			this.NTb.Text = "1000";
			//
			// label9
			//
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(407, 224);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(14, 13);
			this.label9.TabIndex = 16;
			this.label9.Text = "Р";
			//
			// mTb
			//
			this.mTb.Location = new System.Drawing.Point(54, 222);
			this.mTb.Name = "mTb";
			this.mTb.Size = new System.Drawing.Size(100, 20);
			this.mTb.TabIndex = 20;
			this.mTb.Text = "16";
			//
			// methodsList
			//
			this.methodsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
			this.methodsList.FormattingEnabled = true;
			this.methodsList.Items.AddRange(new object[] {
            "Имитация \"Лемера\"",
            "Имитация \"Равномерного распределения\"",
            "Имитация \"Симпсона\"",
            "Имитация \"Экспоненциального распределения\" ",
            "Имитация \"Гамма распределения\"",
            "Имитация \"Нормального (гауссовского) распределения\"",
            "Имитация \"Имитация треугольного распределения\""});
			this.methodsList.Location = new System.Drawing.Point(31, 12);
			this.methodsList.Name = "methodsList";
			this.methodsList.Size = new System.Drawing.Size(899, 108);
			this.methodsList.TabIndex = 30;
			this.methodsList.SelectedIndexChanged += new System.EventHandler(this.methodsList_SelectedIndexChanged);
			//
			// additionalParamsBox
			//
			this.additionalParamsBox.Controls.Add(this.additionalParam2_Tb);
			this.additionalParamsBox.Controls.Add(this.additionalParam2_label);
			this.additionalParamsBox.Controls.Add(this.additionalParam1_Tb);
			this.additionalParamsBox.Controls.Add(this.additionalParam1_label);
			this.additionalParamsBox.Location = new System.Drawing.Point(6, 283);
			this.additionalParamsBox.Name = "additionalParamsBox";
			this.additionalParamsBox.Size = new System.Drawing.Size(174, 118);
			this.additionalParamsBox.TabIndex = 31;
			this.additionalParamsBox.TabStop = false;
			this.additionalParamsBox.Text = "Дополнительные параметры";
			//
			// additionalParam2_Tb
			//
			this.additionalParam2_Tb.Location = new System.Drawing.Point(65, 49);
			this.additionalParam2_Tb.Name = "additionalParam2_Tb";
			this.additionalParam2_Tb.Size = new System.Drawing.Size(100, 20);
			this.additionalParam2_Tb.TabIndex = 32;
			//
			// additionalParam2_label
			//
			this.additionalParam2_label.AutoSize = true;
			this.additionalParam2_label.Location = new System.Drawing.Point(6, 52);
			this.additionalParam2_label.Name = "additionalParam2_label";
			this.additionalParam2_label.Size = new System.Drawing.Size(53, 13);
			this.additionalParam2_label.TabIndex = 32;
			this.additionalParam2_label.Text = "Парам 2:";
			//
			// additionalParam1_Tb
			//
			this.additionalParam1_Tb.Location = new System.Drawing.Point(65, 23);
			this.additionalParam1_Tb.Name = "additionalParam1_Tb";
			this.additionalParam1_Tb.Size = new System.Drawing.Size(100, 20);
			this.additionalParam1_Tb.TabIndex = 32;
			//
			// additionalParam1_label
			//
			this.additionalParam1_label.AutoSize = true;
			this.additionalParam1_label.Location = new System.Drawing.Point(6, 26);
			this.additionalParam1_label.Name = "additionalParam1_label";
			this.additionalParam1_label.Size = new System.Drawing.Size(53, 13);
			this.additionalParam1_label.TabIndex = 32;
			this.additionalParam1_label.Text = "Парам 1:";
			//
			// label6
			//
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(407, 251);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(45, 13);
			this.label6.TabIndex = 32;
			this.label6.Text = "Период";
			//
			// label7
			//
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(407, 277);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(90, 13);
			this.label7.TabIndex = 33;
			this.label7.Text = "Апериодичность";
			//
			// periodTb
			//
			this.periodTb.Location = new System.Drawing.Point(559, 248);
			this.periodTb.Name = "periodTb";
			this.periodTb.ReadOnly = true;
			this.periodTb.Size = new System.Drawing.Size(173, 20);
			this.periodTb.TabIndex = 34;
			//
			// aperiodTb
			//
			this.aperiodTb.Location = new System.Drawing.Point(559, 274);
			this.aperiodTb.Name = "aperiodTb";
			this.aperiodTb.ReadOnly = true;
			this.aperiodTb.Size = new System.Drawing.Size(173, 20);
			this.aperiodTb.TabIndex = 35;
			//
			// Main
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(960, 562);
			this.Controls.Add(this.aperiodTb);
			this.Controls.Add(this.periodTb);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.additionalParamsBox);
			this.Controls.Add(this.methodsList);
			this.Controls.Add(this.valL);
			this.Controls.Add(this.chart);
			this.Controls.Add(this.xTb);
			this.Controls.Add(this.pTb);
			this.Controls.Add(this.aTb);
			this.Controls.Add(this.deltMathTb);
			this.Controls.Add(this.cTb);
			this.Controls.Add(this.dTb);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.MathTb);
			this.Controls.Add(this.mLabel);
			this.Controls.Add(this.computeBtn);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dLabel);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.delMathLabel);
			this.Controls.Add(this.NTb);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.mTb);
			this.Name = "Main";
			this.Text = "Task 2 - Kostenevich.D.A.";
			((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
			this.additionalParamsBox.ResumeLayout(false);
			this.additionalParamsBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.ListBox valL;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.TextBox xTb;
        private System.Windows.Forms.TextBox pTb;
        private System.Windows.Forms.TextBox aTb;
        private System.Windows.Forms.TextBox deltMathTb;
        private System.Windows.Forms.TextBox cTb;
        private System.Windows.Forms.TextBox dTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MathTb;
        private System.Windows.Forms.Label mLabel;
        private System.Windows.Forms.Button computeBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label dLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label delMathLabel;
        private System.Windows.Forms.TextBox NTb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox mTb;
        private System.Windows.Forms.ListBox methodsList;
        private System.Windows.Forms.GroupBox additionalParamsBox;
        private System.Windows.Forms.TextBox additionalParam2_Tb;
        private System.Windows.Forms.Label additionalParam2_label;
        private System.Windows.Forms.TextBox additionalParam1_Tb;
        private System.Windows.Forms.Label additionalParam1_label;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox periodTb;
		private System.Windows.Forms.TextBox aperiodTb;

    }
}

