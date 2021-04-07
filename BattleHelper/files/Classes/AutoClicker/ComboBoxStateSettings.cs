using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BattleHelper.Classes.AutoClicker
{
    class ComboBoxStateSettings
    {
        readonly MsgBoxes msg = new MsgBoxes();

        // sets the start value for combo boxes
        internal int indexComboBoxActivate;
        internal int indexComboBoxDeactivate;

        
        // checks current values of combo boxes to not be the same
        internal void CheckValueCmbActivate(ComboBox activateSC, ComboBox deactivateSC)
        {
            if (activateSC.SelectedIndex == deactivateSC.SelectedIndex)
            {
                msg.StopShortcutError();
                activateSC.SelectedIndex = indexComboBoxActivate;
            }
            else
                indexComboBoxActivate = activateSC.SelectedIndex;
        }

        internal void CheckValueCmbDeactivate(ComboBox deactivateSC, ComboBox activateSC)
        {
            if (deactivateSC.SelectedIndex == activateSC.SelectedIndex)
            {
                msg.StartSchortcutError();
                deactivateSC.SelectedIndex = indexComboBoxDeactivate;
            }
            else
                indexComboBoxDeactivate = deactivateSC.SelectedIndex;
        }


        // enables and disables combo boxes, depends of the radio button state
        internal void EnableCmbs(ComboBox activateSC, ComboBox deactivateSC)
        {
            activateSC.IsEnabled = true;
            deactivateSC.IsEnabled = true;
        }

        internal void DisableCmbs(ComboBox activateSC, ComboBox deactivateSC)
        {
            activateSC.IsEnabled = false;
            deactivateSC.IsEnabled = false;
        }
    }
}
