using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;

namespace Reminder
{
    class KeyboardBlocker
    {
        //private static Logger<KeyboardBlocker> log = new Logger<KeyboardBlocker>();
        private const int SE_PRIVILEGE_ENABLED = 0x00000002;
        private const int TOKEN_QUERY = 0x00000008;
        private const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
        private const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct TokPriv1Luid
        {
            public int Count;
            public long Luid;
            public int Attr;
        }

        public static bool off()
        {
            if (IsAdministrator())
            {
                BlockInput(true);//锁定鼠标及键盘
                return true;
            }
            else
                return false;
        }
        public static bool on()
        {
            if (IsAdministrator())
            {
                BlockInput(false);//解除键盘鼠标锁定
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 是否是管理员权限
        /// </summary>
        /// <returns></returns>
        public static bool IsAdministrator()
        {
            WindowsIdentity current = WindowsIdentity.GetCurrent();
            WindowsPrincipal windowsPrincipal = new WindowsPrincipal(current);
            return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        [DllImport("user32.dll")]
        static extern void BlockInput(bool Block);

    }
}
