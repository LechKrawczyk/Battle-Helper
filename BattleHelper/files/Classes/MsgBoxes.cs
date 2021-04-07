using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BattleHelper.Classes
{
    class MsgBoxes
    {
        private readonly string messageForDistance = "This field accepts only numbers." + "\n" + "Can not start from 0." + "\n" + "Max 3 digits allowed." + "\n" + "And max number is 150.";
        private readonly string messageForAzymyth = "This field accepts only numbers." + "\n" + "Max 3 digits allowed \nand max number is 359.";
        private readonly string caption = "Error detect in input.";
        private readonly string battleHelperCaption = "Battle Helper";
        private readonly string hotKeyActivated = "Global Hot Key Activated.";
        private readonly string hotKeyDeactivated = "Global Hot Key Deactivated.";
        private readonly string startShortcutError = "Value must be different then:" + "\n" + "Shortcut to Activate!";
        private readonly string stopShortcutError = "Value must be different then:" + "\n" + "Shortcut to Deactivate!";
        private readonly string secondTimerError = "The smallest time value betwen clicks is: 0.1 second.";
        private readonly string tenthSecondError = "The smallest time value betwen clicks is: 0.1 second.";
        private readonly string tabControl = "In order to use autoclicker please select:" + "\n" + "Enginer/Miner Tab or Logistics Tab.";

        internal void DistanceMsgBox()
        {
            MessageBox.Show(messageForDistance, caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        internal void AzymuthMsgBox()
        {
            MessageBox.Show(messageForAzymyth, caption, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        internal void ActivateHKMsgBox()
        {
            MessageBox.Show(hotKeyActivated, battleHelperCaption, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        internal void DeactivateHKMsgBox()
        {
            MessageBox.Show(hotKeyDeactivated, battleHelperCaption, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        internal void StartSchortcutError()
        {
            MessageBox.Show(startShortcutError, battleHelperCaption, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        internal void StopShortcutError()
        {
            MessageBox.Show(stopShortcutError, battleHelperCaption, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        internal void SecondTimerError()
        {
            MessageBox.Show(secondTimerError, battleHelperCaption, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        internal void TenthSecondError()
        {
            MessageBox.Show(tenthSecondError, battleHelperCaption, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        internal void SelectTab()
        {
            MessageBox.Show(tabControl, battleHelperCaption, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
