namespace lr4
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbP = new System.Windows.Forms.TextBox();
            this.tbQ = new System.Windows.Forms.TextBox();
            this.tbAverageWorkersA = new System.Windows.Forms.TextBox();
            this.tbBreakingA = new System.Windows.Forms.TextBox();
            this.tbSourceGotA = new System.Windows.Forms.TextBox();
            this.tbAverageWorkersB = new System.Windows.Forms.TextBox();
            this.tbBreakingB = new System.Windows.Forms.TextBox();
            this.tbSourceGotB = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            //
            // tbP
            //
            this.tbP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbP.Location = new System.Drawing.Point(102, 33);
            this.tbP.Name = "tbP";
            this.tbP.Size = new System.Drawing.Size(174, 23);
            this.tbP.TabIndex = 0;
            this.tbP.Text = "2";
            //
            // tbQ
            //
            this.tbQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbQ.Location = new System.Drawing.Point(102, 59);
            this.tbQ.Name = "tbQ";
            this.tbQ.Size = new System.Drawing.Size(174, 23);
            this.tbQ.TabIndex = 1;
            this.tbQ.Text = "6";
            //
            // tbAverageWorkersA
            //
            this.tbAverageWorkersA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbAverageWorkersA.Location = new System.Drawing.Point(36, 161);
            this.tbAverageWorkersA.Name = "tbAverageWorkersA";
            this.tbAverageWorkersA.Size = new System.Drawing.Size(123, 23);
            this.tbAverageWorkersA.TabIndex = 2;
            //
            // tbBreakingA
            //
            this.tbBreakingA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbBreakingA.Location = new System.Drawing.Point(36, 209);
            this.tbBreakingA.Name = "tbBreakingA";
            this.tbBreakingA.Size = new System.Drawing.Size(123, 23);
            this.tbBreakingA.TabIndex = 3;
            //
            // tbSourceGotA
            //
            this.tbSourceGotA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSourceGotA.Location = new System.Drawing.Point(36, 255);
            this.tbSourceGotA.Name = "tbSourceGotA";
            this.tbSourceGotA.Size = new System.Drawing.Size(123, 23);
            this.tbSourceGotA.TabIndex = 4;
            //
            // tbAverageWorkersB
            //
            this.tbAverageWorkersB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbAverageWorkersB.Location = new System.Drawing.Point(176, 161);
            this.tbAverageWorkersB.Name = "tbAverageWorkersB";
            this.tbAverageWorkersB.Size = new System.Drawing.Size(123, 23);
            this.tbAverageWorkersB.TabIndex = 5;
            //
            // tbBreakingB
            //
            this.tbBreakingB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbBreakingB.Location = new System.Drawing.Point(176, 209);
            this.tbBreakingB.Name = "tbBreakingB";
            this.tbBreakingB.Size = new System.Drawing.Size(123, 23);
            this.tbBreakingB.TabIndex = 6;
            //
            // tbSourceGotB
            //
            this.tbSourceGotB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSourceGotB.Location = new System.Drawing.Point(176, 255);
            this.tbSourceGotB.Name = "tbSourceGotB";
            this.tbSourceGotB.Size = new System.Drawing.Size(123, 23);
            this.tbSourceGotB.TabIndex = 7;
            //
            // button1
            //
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(15, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(320, 50);
            this.button1.TabIndex = 8;
            this.button1.Text = "Выполнить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(56, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "p:";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(56, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "q:";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(66, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(247, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Среднее число занятых работников";
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(66, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(257, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Абсолютная пропускная способность";
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(69, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(254, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Среднее число неисправных станков";
            //
            // groupBox1
            //
            this.groupBox1.Controls.Add(this.tbSourceGotB);
            this.groupBox1.Controls.Add(this.tbP);
            this.groupBox1.Controls.Add(this.tbQ);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbAverageWorkersA);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbBreakingA);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbSourceGotA);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbAverageWorkersB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbBreakingB);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(168, 304);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 284);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Имитационная модель СМО";
            //
            // pictureBox2
            //
            this.pictureBox2.Image = global::lr4.Properties.Resources._2___;
            this.pictureBox2.Location = new System.Drawing.Point(356, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(267, 270);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            //
            // pictureBox1
            //
            this.pictureBox1.Image = global::lr4.Properties.Resources._1___;
            this.pictureBox1.Location = new System.Drawing.Point(37, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(267, 270);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 600);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ЛР4";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbP;
        private System.Windows.Forms.TextBox tbQ;
        private System.Windows.Forms.TextBox tbAverageWorkersA;
        private System.Windows.Forms.TextBox tbBreakingA;
        private System.Windows.Forms.TextBox tbSourceGotA;
        private System.Windows.Forms.TextBox tbAverageWorkersB;
        private System.Windows.Forms.TextBox tbBreakingB;
        private System.Windows.Forms.TextBox tbSourceGotB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

