namespace lab8
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.прцоессыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.блокнотToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.блокнотСТекстомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.калькуляторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияОПроцессахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.текущийПроцессToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.блокнотToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.калькуляторToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            //
            // menuStrip1
            //
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.прцоессыToolStripMenuItem,
            this.информацияОПроцессахToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            //
            // прцоессыToolStripMenuItem
            //
            this.прцоессыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.блокнотToolStripMenuItem,
            this.блокнотСТекстомToolStripMenuItem,
            this.калькуляторToolStripMenuItem});
            this.прцоессыToolStripMenuItem.Name = "прцоессыToolStripMenuItem";
            this.прцоессыToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.прцоессыToolStripMenuItem.Text = "Процессы";
            this.прцоессыToolStripMenuItem.Click += new System.EventHandler(this.прцоессыToolStripMenuItem_Click);
            //
            // блокнотToolStripMenuItem
            //
            this.блокнотToolStripMenuItem.Name = "блокнотToolStripMenuItem";
            this.блокнотToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.блокнотToolStripMenuItem.Text = "Блокнот";
            this.блокнотToolStripMenuItem.Click += new System.EventHandler(this.блокнотToolStripMenuItem_Click);
            //
            // блокнотСТекстомToolStripMenuItem
            //
            this.блокнотСТекстомToolStripMenuItem.Name = "блокнотСТекстомToolStripMenuItem";
            this.блокнотСТекстомToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.блокнотСТекстомToolStripMenuItem.Text = "Блокнот с текстом";
            this.блокнотСТекстомToolStripMenuItem.Click += new System.EventHandler(this.блокнотСТекстомToolStripMenuItem_Click);
            //
            // калькуляторToolStripMenuItem
            //
            this.калькуляторToolStripMenuItem.Name = "калькуляторToolStripMenuItem";
            this.калькуляторToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.калькуляторToolStripMenuItem.Text = "Калькулятор";
            this.калькуляторToolStripMenuItem.Click += new System.EventHandler(this.калькуляторToolStripMenuItem_Click);
            //
            // информацияОПроцессахToolStripMenuItem
            //
            this.информацияОПроцессахToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.текущийПроцессToolStripMenuItem,
            this.блокнотToolStripMenuItem1,
            this.калькуляторToolStripMenuItem1});
            this.информацияОПроцессахToolStripMenuItem.Name = "информацияОПроцессахToolStripMenuItem";
            this.информацияОПроцессахToolStripMenuItem.Size = new System.Drawing.Size(163, 20);
            this.информацияОПроцессахToolStripMenuItem.Text = "Информация о процессах";
            //
            // текущийПроцессToolStripMenuItem
            //
            this.текущийПроцессToolStripMenuItem.Name = "текущийПроцессToolStripMenuItem";
            this.текущийПроцессToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.текущийПроцессToolStripMenuItem.Text = "Текущий процесс";
            this.текущийПроцессToolStripMenuItem.Click += new System.EventHandler(this.текущийПроцессToolStripMenuItem_Click);
            //
            // блокнотToolStripMenuItem1
            //
            this.блокнотToolStripMenuItem1.Name = "блокнотToolStripMenuItem1";
            this.блокнотToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.блокнотToolStripMenuItem1.Text = "Блокнот";
            this.блокнотToolStripMenuItem1.Click += new System.EventHandler(this.блокнотToolStripMenuItem1_Click);
            //
            // калькуляторToolStripMenuItem1
            //
            this.калькуляторToolStripMenuItem1.Name = "калькуляторToolStripMenuItem1";
            this.калькуляторToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.калькуляторToolStripMenuItem1.Text = "Калькулятор";
            this.калькуляторToolStripMenuItem1.Click += new System.EventHandler(this.калькуляторToolStripMenuItem1_Click);
            //
            // openFileDialog1
            //
            this.openFileDialog1.FileName = "openFileDialog1";
            //
            // textBox1
            //
            this.textBox1.Location = new System.Drawing.Point(13, 28);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(599, 267);
            this.textBox1.TabIndex = 2;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 307);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem прцоессыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem блокнотToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem блокнотСТекстомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem калькуляторToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem информацияОПроцессахToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem текущийПроцессToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem блокнотToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem калькуляторToolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

