using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BattleHelper.Classes;

namespace BattleHelper
{
    class FinalLocation
    {
        // polar coordinates are distance and azimuth
        // cartesian coordinates are points X and Y

        internal double finalDistance;
        internal double finalAzimuth;

        private double friendlyX;
        private double friendlyY;
        private double enemyX;
        private double enemyY;

        private double translatedFriendlyX;
        private double translatedFriendlyY;
        private double translatedEnemyX;
        private double translatedEnemyY;

        //internal double chyba;


        #region helper Methods
        private double AzimuthToPolar(double azimuthDegrees)
        {
            return (azimuthDegrees - 90) * -1;
        }

        private double ToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

        private double ToDegrees(double radians)
        {
            return radians * (180 / Math.PI);
        }
        #endregion



        #region Methods to assign X and Y points for friendly and enemy
        // changing distance and azimuth of enemy to X and Y cartesian
        private void PolarToCartesianEnemy(double enemyDistance, double enemyAzimuth)
        {
            double polarDegrees = ToRadians(AzimuthToPolar(enemyAzimuth));
            enemyX = enemyDistance * Math.Cos(polarDegrees);
            enemyY = enemyDistance * Math.Sin(polarDegrees);
        }
        //changing distance and azimuth of friendly to X and Y cartesian
        private void PolarToCartesianFriendly(double friendlyDistance, double friendlyAzimuth)
        {
            double polarDegrees = ToRadians(AzimuthToPolar(friendlyAzimuth));
            friendlyX = friendlyDistance * Math.Cos(polarDegrees);
            friendlyY = friendlyDistance * Math.Sin(polarDegrees);
        }
        #endregion

        #region Transforming Cartesian coords to have enemy in origin 0, 0

        private void Transforming()
        {
            double originX = friendlyX;
            double originY = friendlyY;
            translatedFriendlyX = friendlyX + (-originX);
            translatedFriendlyY = friendlyY + (-originY);
            translatedEnemyX = enemyX + (-originX);
            translatedEnemyY = enemyY + (-originY);
        }

        #endregion


        #region Final Calculations
        // finalDistance calculation
        private void FinalDistanceCalculation()
        {
            finalDistance = Math.Sqrt(Math.Pow(translatedFriendlyX - translatedEnemyX, 2) + Math.Pow(translatedFriendlyY - translatedEnemyY, 2));
        }

        // finalAzimuth calculation
        private void FinalAzimuthCalculation()
        {
            finalAzimuth = 0;
            if (finalDistance > 0)
            {
                finalAzimuth = ToDegrees(Math.Asin(Math.Abs(translatedEnemyX) / finalDistance));

                //adjusting degrees relative to what quadrant the target is after translation
                if (translatedEnemyX < 0 && translatedEnemyY >= 0)
                {
                    //enemy in 2nd quadrant
                    finalAzimuth = 360 - finalAzimuth;
                }
                else if (translatedEnemyX < 0 && translatedEnemyY < 0)
                {
                    //enemy in 3rd quadrant
                    finalAzimuth = 180 + finalAzimuth;
                }
                else if (translatedEnemyX >= 0 && translatedEnemyY < 0)
                {
                    // enemyY in 4th quadrant
                    finalAzimuth = 180 - finalAzimuth;
                }
                if (double.IsNaN(finalDistance))
                {
                    finalDistance = 0;
                }
                if (double.IsNaN(finalAzimuth))
                {
                    finalAzimuth = 0;
                }

            }

        }
        #endregion

        internal void CalculateCoordinates(double enemyDistance, double enemyAzimuth, double friendlyDistance, double friendlyAzymuth)
        {
            try
            {
                PolarToCartesianEnemy(enemyDistance, enemyAzimuth);
                PolarToCartesianFriendly(friendlyDistance, friendlyAzymuth);
                Transforming();
                FinalDistanceCalculation();
                FinalAzimuthCalculation();
            }
            catch
            {
                MessageBox.Show("Error in TargetLocation, final calculation sector!");
            }
        }
    }
}
