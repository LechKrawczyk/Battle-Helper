using BattleHelper.Classes;
using BattleHelper.Classes.AutoClicker;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace BattleHelper
{
    class RegisterGlobalHT
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        MsgBoxes msg = new MsgBoxes();
        MouseOperations mouse = new MouseOperations();
        KeyboardEvents keyboardEvents = new KeyboardEvents();

        private IntPtr windowHandle;
        private HwndSource source;

        private const int HOTKEY_ID = 1;
        private bool off = true;

        //Modifiers:
        private static readonly uint MOD_CONTROL = 0x0002;    //CTRL
        //private static readonly uint SHIFT = 0x0004;    //Shift

        // Virtual Keys
        private static readonly uint VK_F1 = 0x70;            //F1
        private static readonly uint VK_F2 = 0x71;            //F2
        private static readonly uint VK_F3 = 0x72;            //F3
        private static readonly uint VK_F4 = 0x73;            //F4
        private static readonly uint VK_F5 = 0x74;            //F5
        private static readonly uint VK_F6 = 0x75;            //F6
        private static readonly uint VK_F7 = 0x76;            //F7
        private static readonly uint VK_F8 = 0x77;            //F8

        #region Assigning Global Shortcuts to ComboBoxes on settings tab

        private uint currentStartHK;
        internal uint currentStopHK;

        internal void SetStartHK(ComboBox startHK)
        {
            switch (startHK.SelectedIndex)
            {
                case 0:
                    currentStartHK = VK_F1;
                    break;
                case 1:
                    currentStartHK = VK_F2;
                    break;
                case 2:
                    currentStartHK = VK_F3;
                    break;
                case 3:
                    currentStartHK = VK_F4;
                    break;
                case 4:
                    currentStartHK = VK_F5;
                    break;
                case 5:
                    currentStartHK = VK_F6;
                    break;
                case 6:
                    currentStartHK = VK_F7;
                    break;
                case 7:
                    currentStartHK = VK_F8;
                    break;
            }
        }
        internal void SetStopHK(ComboBox stopHK)
        {
            switch (stopHK.SelectedIndex)
            {
                case 0:
                    currentStopHK = VK_F1;
                    break;
                case 1:
                    currentStopHK = VK_F2;
                    break;
                case 2:
                    currentStopHK = VK_F3;
                    break;
                case 3:
                    currentStopHK = VK_F4;
                    break;
                case 4:
                    currentStopHK = VK_F5;
                    break;
                case 5:
                    currentStopHK = VK_F6;
                    break;
                case 6:
                    currentStopHK = VK_F7;
                    break;
                case 7:
                    currentStopHK = VK_F8;
                    break;
            }
        }
        #endregion

        #region GlobalHootkey Registration
        internal void ActivateGlobalHK(MainWindow window)
        {
            if (off)
                try
                {
                    windowHandle = new WindowInteropHelper(window).Handle;
                    source = HwndSource.FromHwnd(windowHandle);
                    source.AddHook(HwndHook);

                    RegisterHotKey(windowHandle, HOTKEY_ID, MOD_CONTROL, currentStartHK);   // value (currentStartHK)is taken from Assign Global Shortcuts #region
                    RegisterHotKey(windowHandle, HOTKEY_ID, MOD_CONTROL, currentStopHK);    // value (currentStartHK)is taken from Assign Global Shortcuts #region

                    msg.ActivateHKMsgBox();

                    off = false;
                }
                catch
                {
                    MessageBox.Show("Error occurs while activating Global HotKey");
                }
        }
        internal void DeactivateGlobalHK()
        {
            if (!off)
                try
                {
                    source.RemoveHook(HwndHook);
                    UnregisterHotKey(windowHandle, HOTKEY_ID);
                    off = true;
                    msg.DeactivateHKMsgBox();
                }
                catch
                {
                    MessageBox.Show("Error occurs while deactivating Global HotKey");
                }
        }
        #endregion

        #region PerformClick

        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WM_HOTKEY = 0x0312;
            switch (msg)
            {
                case WM_HOTKEY:
                    switch (wParam.ToInt32())
                    {
                        case HOTKEY_ID:
                            int vkey = (((int)lParam >> 16) & 0xFFFF);
                            if (vkey == currentStartHK)
                            {
                                PickedStartAction();
                            }
                            if (vkey == currentStopHK)
                            {
                                PickedStopAction();
                            }
                            handled = true;
                            break;
                    }
                    break;
            }
            return IntPtr.Zero;
        }
        #endregion

        #region Setting TabControl Index and RadioButtons to true or falls

        private int tabIndex;

        private bool holdLeft;
        private bool holdLeftAndRight;
        private bool holdW;

        private bool singleLeft;
        private bool singleRight;

        internal void GetTabIndex(TabControl tab)
        {
            tabIndex = tab.SelectedIndex;
        }

        internal void GetRadioButtonEnginerTab(RadioButton holdLeftRbt, RadioButton holdLeftAndRightRbt)
        {
            if (holdLeftRbt.IsChecked == true)
            {
                holdLeft = true;
                holdLeftAndRight = false;
            }
            else if (holdLeftAndRightRbt.IsChecked == true)
            {
                holdLeftAndRight = true;
                holdLeft = false;
            }
        }

        internal void GetRadioButtonfromLogisticsTab(RadioButton singleLeftRbt, RadioButton singleRightRbt, RadioButton wRbt)
        {
            if (singleLeftRbt.IsChecked == true)
            {
                singleLeft = true;
                singleRight = false;
                holdW = false;
            }
            else if (singleRightRbt.IsChecked == true)
            {
                singleRight = true;
                singleLeft = false;
                holdW = false;
            }
            else if (wRbt.IsChecked == true)
            {
                holdW = true;
                singleLeft = false;
                singleRight = false;
            }
        }
        #endregion

        #region operations for Tab Control Index 1 and 2

        private void PickedStartAction()
        {
            switch (tabIndex)
            {
                case 0:
                    if (holdLeft == true)
                    {
                        mouse.HoldLeft();                   // comes fromMouse operations
                    }
                    else if (holdLeftAndRight == true)
                    {
                        mouse.HoldLeftAndRight();           // comes fromMouse operations
                    }
                    break;
                case 2:
                    if (singleLeft == true)
                    {
                        start = true;
                        SingleLeftWithLoop();               // comes from region below
                    }
                    else if (singleRight == true)
                    {
                        start = true;
                        SingleLeftPlusShift();              // comes from region below
                    }
                    break;
                    //case 1:
                    //case 3:
                    //    msg.SelectTab();
                    //    break;
            }
        }

        private void PickedStopAction()
        {
            switch (tabIndex)
            {
                case 0:
                    if (holdLeft == true)
                    {
                        mouse.ReleaseLeft();
                    }
                    else if (holdLeftAndRight == true)
                    {
                        mouse.ReleaseLeftAndRight();
                    }
                    break;
                case 2:
                    if (singleLeft == true)
                    {
                        start = false;
                    }
                    else if (singleRight == true)
                    {
                        start = false;
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Operations for Tab Control Index 2 (with loops)

        // This boolean "start" is set to true in PickedStartAction() on Ctrl + (start shortcut)
        // or to false in PickedStopAction() on Ctrl + (stop shortcut)
        private bool start = false;

        private int clickRepetitions = 100;
        private int clickIntervals = 1000;

        private async void SingleLeftWithLoop()
        {
            int i = 0;
            while (start == true && i < clickRepetitions)
            {
                mouse.SingleLeft();
                i++;
                await Task.Delay(clickIntervals);
            }
        }

        private async void SingleLeftPlusShift()
        {
            int i = 0;
            while (start == true && i < clickRepetitions)
            {
                keyboardEvents.ShiftDown();
                mouse.SingleLeft();
                keyboardEvents.ShiftUp();
                i++;
                await Task.Delay(clickIntervals);
            }
        }
        #endregion

        #region Setting click repetitions and time interval for logistic Tool

        internal void ClickRepetitions(ComboBox clickRepetitionsCmb, ComboBox maxRepetitionsCmb)
        {
            if (clickRepetitionsCmb.SelectedIndex == 0)
            {
                clickRepetitions = Convert.ToInt32(maxRepetitionsCmb.Text);
            }
            else
            {
                clickRepetitions = Convert.ToInt32(clickRepetitionsCmb.Text);
            }
        }
        #endregion

        #region Setting Time Interval betwen clicks
        internal void TimeIterval(ComboBox second, ComboBox tenthOfSeceond)
        {
            clickIntervals = (second.SelectedIndex * 1000) + (tenthOfSeceond.SelectedIndex * 100);
        }
        #endregion

    }
}
