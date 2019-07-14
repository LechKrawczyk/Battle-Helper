using BattleHelper.Classes;
using BattleHelper.Classes.AutoClicker;
using BattleHelper.Classes.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // target locator
        InputCheck iCheck = new InputCheck();
        FinalLocation final = new FinalLocation();
        TLRangeIndicator brush = new TLRangeIndicator();

        // auto clicker
        RegisterGlobalHT globalHotKey = new RegisterGlobalHT();
        ComboBoxStateSettings settingsState = new ComboBoxStateSettings();
        ComboBoxStateLogi logiState = new ComboBoxStateLogi();

        public MainWindow()
        {
            InitializeComponent();

            #region Assigning values on program start for AutoClicker
            cmbActivate.IsEnabled = true;                                   // sets combo box enabled
            cmbDeactivate.IsEnabled = true;                                 // sets combo box enabled

            logiState.indexComboBoxSeconds = cmbSecond.SelectedIndex;               //sets current index for cmbSeconds
            logiState.indexComboBoxTenthSecond = cmbTenthOfASecond.SelectedIndex;   //sets current index for cmbTenthSecond


            settingsState.indexComboBoxActivate = cmbActivate.SelectedIndex;        // sets current index for cmbActivate
            settingsState.indexComboBoxDeactivate = cmbDeactivate.SelectedIndex;    // sets current index for cmbDeactivate

            rbtDeactivate.IsChecked = true;                                 // sets radiobutton deactivate to true on start

            #endregion

            //ReadDataBase(); // only for learning purposess
        }

        #region TextChangedEvent for Target Locator
        // distanceToEnemyTxtBox
        // azymuthToEnemyTxtBox
        // distanceToFriendlyTxtBox
        // azymuthToFriendlyTxtBox
        // calculatedDistanceLbl
        // calculatedAzimuthLbl

        private void DistanceToEnemyTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // on text change we call method from Input check to validate data and if data is correct passing it to variables in input check
            iCheck.EnemyDistanceValidation(distanceToEnemyTxtBox);

            final.CalculateCoordinates(iCheck.distanceToEnemy, iCheck.azimuthToEnemy, iCheck.distanceToFriendly, iCheck.azimuthToFriendly);

            calculatedDistanceLbl.Content = Math.Round(final.finalDistance);
            calculatedAzimuthLbl.Content = Math.Round(final.finalAzimuth);

            brush.ColorChange(calculatedDistanceLbl, lblMortar, lblMortarRange, lblHovitzer, lblHovitzerRange, lblFA, lblFARange, lblGB, lblGBRange);
        }

        private void AzymuthToEnemyTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // on text change we call method from Input check to validate data and if data is correct passing it to variables in input check
            iCheck.EnemyAzimuthValidation(azymuthToEnemyTxtBox);

            final.CalculateCoordinates(iCheck.distanceToEnemy, iCheck.azimuthToEnemy, iCheck.distanceToFriendly, iCheck.azimuthToFriendly);

            calculatedDistanceLbl.Content = Math.Round(final.finalDistance);
            calculatedAzimuthLbl.Content = Math.Round(final.finalAzimuth);

            brush.ColorChange(calculatedDistanceLbl, lblMortar, lblMortarRange, lblHovitzer, lblHovitzerRange, lblFA, lblFARange, lblGB, lblGBRange);
        }

        private void DistanceToFriendlyTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // on text change we call method from Input check to validate data and if data is correct passing it to variables in input check
            iCheck.FriendlyDistanceValidation(distanceToFriendlyTxtBox);

            final.CalculateCoordinates(iCheck.distanceToEnemy, iCheck.azimuthToEnemy, iCheck.distanceToFriendly, iCheck.azimuthToFriendly);

            calculatedDistanceLbl.Content = Math.Round(final.finalDistance);
            calculatedAzimuthLbl.Content = Math.Round(final.finalAzimuth);

            brush.ColorChange(calculatedDistanceLbl, lblMortar, lblMortarRange, lblHovitzer, lblHovitzerRange, lblFA, lblFARange, lblGB, lblGBRange);
        }

        private void AzymuthToFriendlyTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // on text change we call method from Input check to validate data and if data is correct passing it to variables in input check
            iCheck.FriendlyAzimuthValidation(azymuthToFriendlyTxtBox);

            final.CalculateCoordinates(iCheck.distanceToEnemy, iCheck.azimuthToEnemy, iCheck.distanceToFriendly, iCheck.azimuthToFriendly);

            calculatedDistanceLbl.Content = Math.Round(final.finalDistance);
            calculatedAzimuthLbl.Content = Math.Round(final.finalAzimuth);

            brush.ColorChange(calculatedDistanceLbl, lblMortar, lblMortarRange, lblHovitzer, lblHovitzerRange, lblFA, lblFARange, lblGB, lblGBRange);
        }
        #endregion

        #region GetFocus SelectAll for Target Locator
        private void DistanceToEnemyTxtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            distanceToEnemyTxtBox.SelectAll();
        }
        private void AzymuthToEnemyTxtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            azymuthToEnemyTxtBox.SelectAll();
        }
        private void DistanceToFriendlyTxtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            distanceToFriendlyTxtBox.SelectAll();
        }
        private void AzymuthToFriendlyTxtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            azymuthToFriendlyTxtBox.SelectAll();
        }
        #endregion

        #region GlobalHK Status
        private void RdbOn_Checked(object sender, RoutedEventArgs e)
        {
            settingsState.DisableCmbs(cmbActivate, cmbDeactivate);
            globalHotKey.SetStartHK(cmbActivate);
            globalHotKey.SetStopHK(cmbDeactivate);

            globalHotKey.ActivateGlobalHK(this);
        }

        private void RbtOff_Checked(object sender, RoutedEventArgs e)
        {
            settingsState.EnableCmbs(cmbActivate, cmbDeactivate);
            globalHotKey.DeactivateGlobalHK();
        }
        #endregion

        #region ComboBox Set Shortcuts for Global Hotkey
        private void CmbActivate_DropDownClosed(object sender, EventArgs e)
        {
            settingsState.CheckValueCmbActivate(cmbActivate, cmbDeactivate);
        }
        private void CmbDeactivate_DropDownClosed(object sender, EventArgs e)
        {
            settingsState.CheckValueCmbDeactivate(cmbDeactivate, cmbActivate);
        }
        #endregion

        #region TabControlIndexSelection
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            globalHotKey.GetTabIndex(tabControl);
        }
        #endregion

        #region Radio Button Enginer Tab Selection
        private void RbtHoldLeft_Checked(object sender, RoutedEventArgs e)
        {
            globalHotKey.GetRadioButtonEnginerTab(rbtHoldLeft, rbtHoldLeftAndRight);
        }

        private void RbtHoldLeftAndRight_Checked(object sender, RoutedEventArgs e)
        {
            globalHotKey.GetRadioButtonEnginerTab(rbtHoldLeft, rbtHoldLeftAndRight);
        }

        #endregion

        #region Radio Button Logistics Tab Selection
        private void RbtSingleLeft_Checked(object sender, RoutedEventArgs e)
        {
            globalHotKey.GetRadioButtonfromLogisticsTab(rbtSingleLeft, rbtSingleRight);
        }

        private void RbtSingleRight_Checked(object sender, RoutedEventArgs e)
        {
            globalHotKey.GetRadioButtonfromLogisticsTab(rbtSingleLeft, rbtSingleRight);
        }

        #endregion

        #region Value for cmbRepetition and cmbMaxRepetition

        private void CmbClickRepetition_DropDownClosed(object sender, EventArgs e)
        {
            globalHotKey.ClickRepetitions(cmbClickRepetition, cmbMaxRepetition);
        }

        private void CmbMaxRepetition_DropDownClosed(object sender, EventArgs e)
        {
            globalHotKey.ClickRepetitions(cmbClickRepetition, cmbMaxRepetition);
        }


        #endregion

        #region Evaluating value and Setting Value for cmbSecond and cmbTenthOfSecond
        private void CmbSecond_DropDownClosed(object sender, EventArgs e)
        {
            logiState.CheckValueCmbSeconds(cmbSecond, cmbTenthOfASecond);
            globalHotKey.TimeIterval(cmbSecond, cmbTenthOfASecond);
        }

        private void CmbTenthOfASecond_DropDownClosed(object sender, EventArgs e)
        {
            logiState.CheckValueCmbTenthSecond(cmbTenthOfASecond, cmbSecond);
            globalHotKey.TimeIterval(cmbSecond, cmbTenthOfASecond);
        }

        #endregion

    }
}
