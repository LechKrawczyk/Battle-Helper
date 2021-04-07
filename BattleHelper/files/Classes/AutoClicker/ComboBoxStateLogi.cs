using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BattleHelper.Classes.AutoClicker
{
    class ComboBoxStateLogi
    {
        MsgBoxes msg = new MsgBoxes();

        // sets the start value for combo boxes
        internal int indexComboBoxSeconds;
        internal int indexComboBoxTenthSecond;


        internal void CheckValueCmbSeconds(ComboBox seconds, ComboBox tenthSecond)
        {
            if(seconds.SelectedIndex == 0 && tenthSecond.SelectedIndex == 0)
            {
                msg.SecondTimerError();
                seconds.SelectedIndex = indexComboBoxSeconds;
            }
            indexComboBoxSeconds = seconds.SelectedIndex;
        }

        internal void CheckValueCmbTenthSecond(ComboBox tenthSecond, ComboBox second)
        {
            if(tenthSecond.SelectedIndex == 0 && second.SelectedIndex == 0)
            {
                msg.TenthSecondError();
                tenthSecond.SelectedIndex = indexComboBoxTenthSecond;
            }
            indexComboBoxTenthSecond = tenthSecond.SelectedIndex;
        }
    }
}
