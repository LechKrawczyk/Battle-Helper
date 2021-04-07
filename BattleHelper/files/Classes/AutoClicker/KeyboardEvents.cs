using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BattleHelper
{
    class KeyboardEvents
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public const int KEYEVENTF_EXTENDEDKEY = 0x0001; //Key down flag
        public const int KEYEVENTF_KEYUP = 0x0002; //Key up flag

        // Declare some keyboard keys as constants with its respective code
        public const int VK_SHIFT = 0x10; //Shift key code
        public const int VK_W = 0x57; //W on keyboard

        internal void ShiftUp()
        {
            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
        }
        internal void ShiftDown()
        {
            keybd_event(VK_SHIFT, 0, KEYEVENTF_EXTENDEDKEY, 0);
        }
        internal void W_KeyDown()
        {
            keybd_event(VK_W, 0, KEYEVENTF_EXTENDEDKEY, 0);
        }
        internal void W_KeyUp()
        {
            keybd_event(VK_W, 0, KEYEVENTF_KEYUP, 0);
        }
    }
}
