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
using phonebook_desktop.Controllers;

namespace phonebook_desktop.Views
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Window
    {
        dbController dbc = new dbController();
        public Create()
        {
            InitializeComponent();
        }

        private void btnClick_SaveContact(object sender, RoutedEventArgs e)
        {
            contactController.createContact(lastName.Text, firstName.Text, middleName.Text, gender.Text, phoneNumber.Text);
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void btnClick_BackToHome(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}
