using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using IWshRuntimeLibrary;

namespace Reminder
{
    public partial class MainFrm : Form
    {
        WorkFrm wrkFrm;
        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {

        }
       

        private void Btn_start_Click(object sender, EventArgs e)
        {
            bool input_flag;

            if (this.ckBoxInput.Checked)
            {
                input_flag = true;
            }
            else {
                input_flag = false;
            }

            bool auto_start;
            auto_start = checkBox1.Checked;
            SetAutoStart(auto_start);

            int wrkTime = (int)this.numWrkTime.Value;
            int rstTime = (int)this.numRstTime.Value;
            wrkFrm = new WorkFrm(wrkTime,rstTime,input_flag);
            wrkFrm.Show();
            //MainFrm.Visible = false;
            this.Visible = false;

        }

        private void 主窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            if (wrkFrm!=null)
            {
                wrkFrm.Close();
            }
            

        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {            
            //取消关闭窗口
            e.Cancel = true;
            //最小化主窗口
            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
            //不在系统任务栏显示主窗口图标
            this.ShowInTaskbar = false;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            System.Environment.Exit(0);
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private string QuickName = "Reminder";

        private string systemStartPath { get { return Environment.GetFolderPath(Environment.SpecialFolder.Startup); } }

        private string appAllPath { get { return Process.GetCurrentProcess().MainModule.FileName; } }

        private void SetAutoStart(bool auto_run)
        {
            // get the path set of this software
            List<string> shortcurPaths = GetQuickFromFolder(systemStartPath, appAllPath);
            if (auto_run)
            {
                if (shortcurPaths.Count > 1)
                {
                    for (int i = 1; i < shortcurPaths.Count; i++)
                    {
                        DeleteFile(shortcurPaths[i]);
                    }
                }
                else if (shortcurPaths.Count == 0)
                {
                    bool res = CreateShortcut(systemStartPath, QuickName, appAllPath, "Reminder");
                }
            }
            else
            {
                if (shortcurPaths.Count > 0)
                {
                    for (int i = 0; i < shortcurPaths.Count; i++)
                    {
                        DeleteFile(shortcurPaths[i]);
                    }
                }
            }
        }

        private bool CreateShortcut(string systemStartPath, string quickName, string appAllPath, string description = null)
        {
            try
            {
                if (!Directory.Exists(systemStartPath)) Directory.CreateDirectory(systemStartPath);
                string shortcutPath = Path.Combine(systemStartPath, string.Format("{0}.lnk", quickName));
                WshShell shell = new IWshRuntimeLibrary.WshShell();
                IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutPath);
                shortcut.TargetPath = appAllPath;
                shortcut.WorkingDirectory = Path.GetDirectoryName(shortcutPath);
                shortcut.WindowStyle = 1;
                shortcut.Description = description;
                shortcut.IconLocation = "ICO2.ico";
                shortcut.Save();
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return false;
        }

        private void DeleteFile(string path)
        {
            FileAttributes attr = System.IO.File.GetAttributes(path);
            if (attr == FileAttributes.Directory)
            {
                Directory.Delete(path, true);
            }
            else
            {
                System.IO.File.Delete(path);
            }
        }

        private List<string> GetQuickFromFolder(string systemStartPath, string appAllPath)
        {
            List<string> tmpStrs = new List<string>();
            String tmpStr = null;
            String[] files = Directory.GetFiles(systemStartPath, "*.lnk");
            for (int i = 0; i < files.Length; i++)
            {
                tmpStr = GetAppPathFromQuick(files[i]);
                if (tmpStr == appAllPath)
                {
                    tmpStrs.Add(files[i]);
                }
            }
            return tmpStrs;
        }

        private string GetAppPathFromQuick(string shortcutPath)
        {
            if (System.IO.File.Exists(shortcutPath))
            {
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
                return shortcut.TargetPath;
            }
            else
            {
                return null;
            }
        }
    }
}
