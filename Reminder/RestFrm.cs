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
    public partial class RestFrm : Form
    {
        private int rst_m;
        private int wrk_m;
        private int rst_m2;
        private bool input_flag;
        int rst_s = 0;
        public RestFrm()
        {
            InitializeComponent();
        }
        public RestFrm(int rst_minutes,int wrk_minutes, bool input_flag)
        {
            InitializeComponent();
            this.rst_m = rst_minutes;
            this.wrk_m = wrk_minutes;
            this.rst_m2 = rst_minutes;
            this.input_flag = input_flag;
        }
        
        private void RestFrm_Load(object sender, EventArgs e)
        {
            if (input_flag)
            {
                lblText.Text = "您已久坐" + rst_m.ToString() + "分钟了，键盘和鼠标被锁定，站起来活动下！";
            }
            else
            {
                lblText.Text = "您已久坐" + rst_m.ToString() + "分钟了，站起来活动下！Alt+F4 退出本界面。";
            }

            //lblText.Text = "您已久坐60分钟了，键盘和鼠标被锁定，站起来活动下！";

            timerRst.Enabled = true;            
            this.TopMost = true;
           
            this.WindowState = FormWindowState.Maximized;
            this.Opacity = 0.75;
            if (input_flag)
            {
                KeyboardBlocker.off();//锁定键盘
            }

            if (rst_s >= 10)
            {
                lbl_seconds.Text = rst_s.ToString();
            }
            else
            {
                lbl_seconds.Text = "0"+rst_s.ToString();
            }


            if (rst_m >= 10)
            {
                lbl_minutes.Text = rst_m.ToString();
            }
            else
            {
                lbl_minutes.Text = "0" + rst_m.ToString();
            }
            
            

        }

        private void TimerRst_Tick(object sender, EventArgs e)
        {
            timing();
        }

        private void timing()
        {
            if (rst_s > 0)
            {
                rst_s = rst_s - 1;
                if (rst_s >= 10)
                {
                    lbl_seconds.Text = rst_s.ToString();
                }
                else
                {
                    lbl_seconds.Text = "0"+rst_s.ToString();
                }
                
            }
            else //秒=0时，分钟-1
            {
                timerRst.Enabled = false;
                rst_m--;
                if (rst_m>=10) {
                    lbl_minutes.Text = rst_m.ToString();
                }
                else
                {
                    lbl_minutes.Text = "0"+rst_m.ToString();
                }
                
                if (rst_m > -1) //若分钟不为0，秒回到60，继续递归
                {
                    timerRst.Enabled = true;
                    rst_s = 59;
                    timing();
                }
                else
                {
                    WorkFrm workFrm = new WorkFrm(wrk_m,rst_m2,input_flag);
                    workFrm.Show();
                    this.Close();
                    if (input_flag)
                    {
                        KeyboardBlocker.on();//解锁键盘
                    }
                }
            }
        }

        private void RestFrm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void RestFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            WorkFrm workFrm = new WorkFrm(wrk_m, rst_m2, input_flag);
            workFrm.Show();
        }
    }
}
