using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Reminder
{
    public partial class WorkFrm : Form
    {
        private int wrk_minutes;//工作时间(分)
        private int wrk_seconds;//工作时间(秒)
        private int wrk_m;
        private int rst_minutes;//休息时间(分)
        private bool input_flag;//是否选中锁定键盘
        private bool left_flag;//鼠标左键是否点击
        private Point mouseoff;
        private RestFrm[] restFrms;
        public WorkFrm()
        {
            InitializeComponent();
        }
        //定义一个构造函数，接受前一个窗体传来的参数
        public WorkFrm(int wrk_minutes, int rst_minutes,bool input_flag)
        {
            InitializeComponent();           
            this.wrk_minutes = wrk_minutes;
            this.rst_minutes = rst_minutes;
            //this.input_flag = input_flag;
            this.wrk_m = wrk_minutes;
            this.input_flag = input_flag;

            int x = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Width - 160;
            int y = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Height - 90;
            Point p = new Point(x, y);
            this.PointToScreen(p);
            this.Location = p;
            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

            //任务栏高度
            //Size OutTaskBarSize = new Size(SystemInformation.WorkingArea.Width, SystemInformation.WorkingArea.Height);
            //Size ScreenSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            //this.Height = ScreenSize.Height - OutTaskBarSize.Height;
            //Size TaskBarSize;

            //TaskBarSize = new Size(
            //                (ScreenSize.Width - (ScreenSize.Width - OutTaskBarSize.Width)),
            //                (ScreenSize.Height - OutTaskBarSize.Height)
             //               );
            

            wrk_seconds = 0; 

            if (wrk_seconds >= 10)
            {
                lblSecond.Text = wrk_seconds.ToString();
            }
            else
            {
                lblSecond.Text = "0" + wrk_seconds.ToString();
            }

            if (wrk_minutes>=10) {
                lblMin.Text = wrk_minutes.ToString();
            }
            else
            {
                lblMin.Text = "0"+wrk_minutes.ToString();
            }

            this.Opacity = 0.8;
            
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timing();
        }

        /// <summary>
        /// 递归的方式倒计时
        /// </summary>
        public  void timing()
        {
            Warn();

            if (wrk_seconds > 0)
            {
                wrk_seconds = wrk_seconds - 1;
                if (wrk_seconds >= 10)
                {
                    lblSecond.Text = wrk_seconds.ToString();
                }
                else
                {
                    lblSecond.Text = "0"+wrk_seconds.ToString();
                }
               
            }
            else //秒=0时，分钟-1
            {
                timerWrk.Enabled = false;
                wrk_minutes--;
                if (wrk_minutes >= 10)
                {
                    lblMin.Text = wrk_minutes.ToString();
                }
                else
                {
                    lblMin.Text = "0"+wrk_minutes.ToString();
                }
                
                if (wrk_minutes > -1) //若分钟不为0，秒回到60，继续递归
                {
                    timerWrk.Enabled = true;
                    wrk_seconds = 60;
                    
                    timing();
                }
                else
                {

                    this.Close();
                    /*RestFrm restFrm = new RestFrm(rst_minutes, wrk_m, input_flag);
                    restFrm.ShowDialog();  */

                    // create Restfrm on every screen;
                    restFrms = new RestFrm[Screen.AllScreens.Count()];
                    int i = 0;
                    foreach(var screen in Screen.AllScreens)
                    {
                        restFrms[i] = new RestFrm(rst_minutes, wrk_m, input_flag, screen.Primary, screen.Bounds.Location);
                        restFrms[i++].Show();
                    }
                }
            }
        }

        /// <summary>
        /// 工作的最后15秒提醒
        /// </summary>
        private void Warn()
        {
            if (wrk_minutes==0&&wrk_seconds<=16)
            {
                this.BackColor = Color.Red;
                lblWarn.ForeColor = Color.Yellow;
                lblWarn.Text = "该休息了！";
                int x = (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Width) / 2 - this.Width/2;
                int y = (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Height) / 2 - this.Height/2;
                Point p = new Point(x, y);
                this.PointToScreen(p);
                this.Location = p;
            }         
            
        }

        /// <summary>
        /// 让程序不显示在alt+Tab视图窗体中
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_APPWINDOW = 0x40000;
                const int WS_EX_TOOLWINDOW = 0x80;
                CreateParams cp = base.CreateParams;
                cp.ExStyle &= (~WS_EX_APPWINDOW);    // 不显示在TaskBar
                cp.ExStyle |= WS_EX_TOOLWINDOW;      // 不显示在Alt+Tab
                return cp;
            }
        }


        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void LblSecond_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
        private void mouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseoff = new Point(e.X, e.Y);
                left_flag = true;

            }
        }
        private void mouseMove()
        {
            if (left_flag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(-mouseoff.X, -mouseoff.Y);//这里注意下-的用意，offset
                Location = mouseSet;
            }
        }
        private void mouseUp()
        {
            if (left_flag)
            {
                left_flag = false;
            }
        }
        private void WorkFrm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown(e);
        }

        private void WorkFrm_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove();
        }

        private void WorkFrm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseUp();
        }

      

        private void LblWarn_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void LblWarn_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void LblWarn_MouseUp(object sender, MouseEventArgs e)
        {
           
        }
    }
}
