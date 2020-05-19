namespace Reminder
{
    partial class WorkFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkFrm));
            this.timerWrk = new System.Windows.Forms.Timer(this.components);
            this.lblSecond = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblWarn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timerWrk
            // 
            this.timerWrk.Enabled = true;
            this.timerWrk.Interval = 1000;
            this.timerWrk.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.BackColor = System.Drawing.Color.Transparent;
            this.lblSecond.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.lblSecond.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecond.ForeColor = System.Drawing.Color.White;
            this.lblSecond.Location = new System.Drawing.Point(94, 33);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(27, 19);
            this.lblSecond.TabIndex = 4;
            this.lblSecond.Text = "  ";
            this.lblSecond.Click += new System.EventHandler(this.LblSecond_Click);
            this.lblSecond.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WorkFrm_MouseDown);
            this.lblSecond.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WorkFrm_MouseMove);
            this.lblSecond.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WorkFrm_MouseUp);
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.BackColor = System.Drawing.Color.Transparent;
            this.lblMin.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMin.ForeColor = System.Drawing.Color.White;
            this.lblMin.Location = new System.Drawing.Point(55, 33);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(27, 19);
            this.lblMin.TabIndex = 5;
            this.lblMin.Text = "  ";
            this.lblMin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WorkFrm_MouseDown);
            this.lblMin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WorkFrm_MouseMove);
            this.lblMin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WorkFrm_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(80, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = ":";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WorkFrm_MouseDown);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WorkFrm_MouseMove);
            this.label2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WorkFrm_MouseUp);
            // 
            // label3
            // 
            this.label3.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(4, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 37);
            this.label3.TabIndex = 8;
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WorkFrm_MouseDown);
            this.label3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WorkFrm_MouseMove);
            this.label3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WorkFrm_MouseUp);
            // 
            // lblWarn
            // 
            this.lblWarn.AutoSize = true;
            this.lblWarn.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.lblWarn.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWarn.ForeColor = System.Drawing.Color.White;
            this.lblWarn.Location = new System.Drawing.Point(33, 8);
            this.lblWarn.Name = "lblWarn";
            this.lblWarn.Size = new System.Drawing.Size(93, 20);
            this.lblWarn.TabIndex = 7;
            this.lblWarn.Text = "注意坐姿";
            this.lblWarn.Click += new System.EventHandler(this.Label1_Click);
            this.lblWarn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WorkFrm_MouseDown);
            this.lblWarn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WorkFrm_MouseMove);
            this.lblWarn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WorkFrm_MouseUp);
            // 
            // WorkFrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(148, 55);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblWarn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblSecond);
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "WorkFrm";
            this.Opacity = 0.85D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "wrkFrm";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WorkFrm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WorkFrm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WorkFrm_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerWrk;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblWarn;
    }
}

