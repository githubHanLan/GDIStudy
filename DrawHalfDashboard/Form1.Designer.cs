namespace DrawHalfDashboard
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.dashboardUC1 = new DrawHalfDashboard.DashboardUC();
            this.halfDashboardUC1 = new DrawHalfDashboard.HalfDashboardUC();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(589, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dashboardUC1
            // 
            this.dashboardUC1.CurrentValue = 200F;
            this.dashboardUC1.Location = new System.Drawing.Point(503, 124);
            this.dashboardUC1.Name = "dashboardUC1";
            this.dashboardUC1.Size = new System.Drawing.Size(196, 206);
            this.dashboardUC1.TabIndex = 3;
            this.dashboardUC1.Text = "dashboardUC1";
            // 
            // halfDashboardUC1
            // 
            this.halfDashboardUC1.BackColor = System.Drawing.SystemColors.Info;
            this.halfDashboardUC1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("halfDashboardUC1.BackgroundImage")));
            this.halfDashboardUC1.ChangeValue = 0F;
            this.halfDashboardUC1.Location = new System.Drawing.Point(34, 35);
            this.halfDashboardUC1.MaxValue = 123F;
            this.halfDashboardUC1.MinValue = 0F;
            this.halfDashboardUC1.Name = "halfDashboardUC1";
            this.halfDashboardUC1.PinColor = System.Drawing.Color.OrangeRed;
            this.halfDashboardUC1.Size = new System.Drawing.Size(415, 262);
            this.halfDashboardUC1.TabIndex = 2;
            this.halfDashboardUC1.Text = "halfDashboardUC1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dashboardUC1);
            this.Controls.Add(this.halfDashboardUC1);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private HalfDashboardUC halfDashboardUC1;
        private DashboardUC dashboardUC1;
    }
}

