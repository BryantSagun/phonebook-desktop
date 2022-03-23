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
            if (!contactController.checkValidString(lastName.Text) |
                !contactController.checkValidString(firstName.Text) |
                !contactController.checkValidString(middleName.Text) |
                !contactController.checkValidString(gender.Text) |
                !contactController.checkValidString(phoneNumber.Text)
                )
            {
                MessageBox.Show("There are empty fields. Please check your form.");
            }
            else if (!contactController.checkIfStringIsNumeric(phoneNumber.Text))
            {
                MessageBox.Show("Contact Number is invalid. Please update the field.");
            }
            else
            {
                contactController.createContact(lastName.Text.ToUpper(),
                firstName.Text.ToUpper(),
                middleName.Text.ToUpper(),
                gender.Text,
                phoneNumber.Text);
                MainWindow mainWindow = new MainWindow();
                this.Close();
                mainWindow.Show();
            }
        }

        private void btnClick_BackToHome(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void AllowNumbersOnlyInTextbox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void AllowAlphabetsOnlyInTextbox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = !regex.IsMatch(e.Text);
        }
    }
}
