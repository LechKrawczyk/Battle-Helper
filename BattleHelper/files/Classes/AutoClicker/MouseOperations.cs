using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BattleHelper.Classes.AutoClicker
{
    class MouseOperations
    {
        [DllImport("user32.dll", EntryPoint = "mouse_event")]
        private static extern void Mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);


        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        internal void SingleLeft()
        {
            Mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            Mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        internal void SingleRight()
        {
            Mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
            Mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
        }

        internal void HoldLeft()
        {
            Mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
        }

        internal void ReleaseLeft()
        {
            Mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        internal void HoldLeftAndRight()
        {
            Mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
            Mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
        }

        internal void ReleaseLeftAndRight()
        {
            Mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
            Mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
    }
}
