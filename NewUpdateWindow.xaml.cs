using BattleHelper.Classes.DataBase;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BattleHelper
{
    /// <summary>
    /// Interaction logic for NewUpdateWindow.xaml
    /// </summary>
    public partial class NewUpdateWindow : Window
    {
        public NewUpdateWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Save Contact
            //ItemLogistic itemLogistic = new ItemLogistic()
            //{
            //    Picture = pictureImage,

            //    Name = nameTextBox.ToString(),
            //    Description = descriptionTextBox.ToString(),

            //    SoldierA = soldierATextBox.ToString(),
            //    SoldierB = soldierBTextBox.ToString(),
            //    SoldierC = soldierCTextBox.ToString(),
            //    SoldierD = soldierDTextBox.ToString(),
            //    TruckA = truckATextBox.ToString(),
            //    TruckB = truckBTextBox.ToString(),
            //    TruckC = truckCTextBox.ToString(),
            //    TruckD = truckDTextBox.ToString(),
            //    JeepA = jeepATextBox.ToString(),
            //    JeepB = jeepBTextBox.ToString(),
            //    JeepC = jeepCTextBox.ToString(),
            //    JeepD = jeepDTextBox.ToString(),
            //    Other1A = other1ATextBox.ToString(),
            //    Other1B = other1BTextBox.ToString(),
            //    Other1C = other1CTextBox.ToString(),
            //    Other1D = other1DTextBox.ToString(),
            //    Other2A = other2ATextBox.ToString(),
            //    Other2B = other2BTextBox.ToString(),
            //    Other2C = other2CTextBox.ToString(),
            //    Other2D = other2DTextBox.ToString(),
            //    Other3A = other3ATextBox.ToString(),
            //    Other3B = other3BTextBox.ToString(),
            //    Other3C = other3CTextBox.ToString(),
            //    Other3D = other3DTextBox.ToString(),

            //    ProductionTime1 = prodTimeATextBox.ToString(),
            //    ProductionTime4 = prodTimeBTextBox.ToString(),

            //    Capacity1 = crateCapATextBox.ToString(),
            //    Capacity4 = crateCapBTextBox.ToString(),

            //    BMatsA = bMatsATextBox.ToString(),
            //    RMatsA = rMatsATextBox.ToString(),
            //    EMatsA = eMatsATextBox.ToString(),
            //    HEMatsA = hEMatsATextBox.ToString(),

            //    BMatsB = bMatsBTextBox.ToString(),
            //    RmatsB = rMatsBTextBox.ToString(),
            //    EMatsB = eMatsBTextBox.ToString(),
            //    HEMatsB = hEMatsBTextBox.ToString()
            //};

            //using (SQLiteConnection connection = new SQLiteConnection(DBPath.dataBasePath))
            //{
            //    connection.CreateTable<ItemLogistic>(); // if the table already exist, the method below will not be called
            //    connection.Insert(itemLogistic);
            //}

            #region regular way of closing connection
            //SQLiteConnection connection = new SQLiteConnection(dataBasePath);
            //connection.CreateTable<ItemLogistic>(); // if the table already exist, the method below will not be called
            //connection.Insert(itemLogistic);
            //connection.Close();
            #endregion

            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
