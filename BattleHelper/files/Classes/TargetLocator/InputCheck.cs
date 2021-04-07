using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BattleHelper.Classes
{


    class InputCheck
    {
        internal double distanceToEnemy;
        internal double distanceToFriendly;
        internal double azimuthToEnemy;
        internal double azimuthToFriendly;

        Regex validateD = new Regex("^^$|^[1-9][0-9]*$");
        Regex validateA = new Regex("^^$|[0-9][0-9]*$");
        MsgBoxes message = new MsgBoxes();

        //checking enemy distance input
        public void EnemyDistanceValidation(TextBox input)
        {
            Match matchED = validateD.Match(input.Text);
            if (!matchED.Success || input.Text.Length > 3)
            {
                message.DistanceMsgBox();
                input.Clear();
            }
            else if (int.TryParse(input.Text, out int distance))
            {
                if (distance > 150)
                {
                    message.DistanceMsgBox();
                    input.Clear();
                }
                else
                {
                    distanceToEnemy = distance;
                }
            }
        }

        //checking friendly distance input
        public void FriendlyDistanceValidation(TextBox input)
        {
            Match matchED = validateD.Match(input.Text);
            if (!matchED.Success || input.Text.Length > 3)
            {
                message.DistanceMsgBox();
                input.Clear();
            }
            else if (int.TryParse(input.Text, out int distance))
            {
                if (distance > 150)
                {
                    message.DistanceMsgBox();
                    input.Clear();
                }
                else
                {
                    distanceToFriendly = distance;
                }
            }
        }

        //checking enemy azimuth input
        public void EnemyAzimuthValidation(TextBox input)
        {
            Match matchEA = validateA.Match(input.Text);
            if(!matchEA.Success || input.Text.Length > 3)
            {
                message.AzymuthMsgBox();
                input.Clear();
            }
            else if (int.TryParse(input.Text, out int azimuth))
            {
                if (azimuth > 359)
                {
                    message.AzymuthMsgBox();
                    input.Clear();
                }
                else
                    azimuthToEnemy = azimuth;
            }
        }

        //checking friendly azimuth input
        public void FriendlyAzimuthValidation(TextBox input)
        {
            Match matchEA = validateA.Match(input.Text);
            if (!matchEA.Success || input.Text.Length > 3)
            {
                message.AzymuthMsgBox();
                input.Clear();
            }
            else if (int.TryParse(input.Text, out int azimuth))
            {
                if (azimuth > 359)
                {
                    message.AzymuthMsgBox();
                    input.Clear();
                }
                else
                    azimuthToFriendly = azimuth;
            }
        }
    }
}
