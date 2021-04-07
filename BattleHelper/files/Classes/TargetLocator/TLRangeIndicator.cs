using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;



namespace BattleHelper.Classes
{
    class TLRangeIndicator
    {
        internal void ColorChange(Label distance, Label mortar, Label mortarRange, Label hovitzer, Label hovitzerRange, Label fA, Label fARange, Label gB, Label gBRange)
        {
            //mortar
            if(distance.Content != null)
            {
                if ((double)distance.Content < 45 || (double)distance.Content > 65)
                {
                    mortar.Foreground = Brushes.Red;
                    mortarRange.Foreground = Brushes.Red;
                }
                else
                {
                    mortar.Foreground = Brushes.White;
                    mortarRange.Foreground = Brushes.White;
                }
            }
            //Hovitzer & FA
            if(distance.Content != null)
            {
                if ((double)distance.Content < 75 || (double)distance.Content > 150)
                {
                    hovitzer.Foreground = Brushes.Red;
                    hovitzerRange.Foreground = Brushes.Red;
                    fA.Foreground = Brushes.Red;
                    fARange.Foreground = Brushes.Red;
                }
                else
                {
                    hovitzer.Foreground = Brushes.White;
                    hovitzerRange.Foreground = Brushes.White;
                    fA.Foreground = Brushes.White;
                    fARange.Foreground = Brushes.White;
                }
            }
            //GunBoat
            if (distance.Content != null)
            {
                if ((double)distance.Content < 50 || (double)distance.Content > 100)
                {
                    gB.Foreground = Brushes.Red;
                    gBRange.Foreground = Brushes.Red;
                }
                else
                {
                    gB.Foreground = Brushes.White;
                    gBRange.Foreground = Brushes.White;
                }
            }

        }


    }
}
