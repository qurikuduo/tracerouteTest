namespace tracertTest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.numericUpDown_Timeout = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_MaxHops = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_host = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_Logs = new System.Windows.Forms.TextBox();
            this.button_stop = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Timeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxHops)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_stop);
            this.groupBox1.Controls.Add(this.button_OK);
            this.groupBox1.Controls.Add(this.numericUpDown_Timeout);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericUpDown_MaxHops);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_host);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(889, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting";
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(450, 18);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 6;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // numericUpDown_Timeout
            // 
            this.numericUpDown_Timeout.Location = new System.Drawing.Point(379, 19);
            this.numericUpDown_Timeout.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_Timeout.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDown_Timeout.Name = "numericUpDown_Timeout";
            this.numericUpDown_Timeout.Size = new System.Drawing.Size(53, 21);
            this.numericUpDown_Timeout.TabIndex = 5;
            this.numericUpDown_Timeout.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Timeout";
            // 
            // numericUpDown_MaxHops
            // 
            this.numericUpDown_MaxHops.Location = new System.Drawing.Point(287, 19);
            this.numericUpDown_MaxHops.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown_MaxHops.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_MaxHops.Name = "numericUpDown_MaxHops";
            this.numericUpDown_MaxHops.Size = new System.Drawing.Size(40, 21);
            this.numericUpDown_MaxHops.TabIndex = 3;
            this.numericUpDown_MaxHops.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "MaxHops";
            // 
            // textBox_host
            // 
            this.textBox_host.Location = new System.Drawing.Point(54, 20);
            this.textBox_host.Name = "textBox_host";
            this.textBox_host.Size = new System.Drawing.Size(173, 21);
            this.textBox_host.TabIndex = 1;
            this.textBox_host.Text = "8.8.8.8";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP/Host";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_Logs);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(889, 306);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Console";
            // 
            // textBox_Logs
            // 
            this.textBox_Logs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Logs.Location = new System.Drawing.Point(3, 17);
            this.textBox_Logs.Multiline = true;
            this.textBox_Logs.Name = "textBox_Logs";
            this.textBox_Logs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Logs.Size = new System.Drawing.Size(883, 286);
            this.textBox_Logs.TabIndex = 0;
            // 
            // button_stop
            // 
            this.button_stop.Enabled = false;
            this.button_stop.Location = new System.Drawing.Point(531, 18);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(75, 23);
            this.button_stop.TabIndex = 7;
            this.button_stop.Text = "Stop";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 353);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "tracertTest";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Timeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxHops)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown_Timeout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_MaxHops;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_host;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.TextBox textBox_Logs;
        private System.Windows.Forms.Button button_stop;
    }
}

