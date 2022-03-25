using phonebook_desktop.Controllers;
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

namespace phonebook_desktop.Views
{
    public partial class Edit : Window
    {
        public Edit(string lastName, string firstName, string middleName, string gender, string phoneNumber, string id)
        {
            InitializeComponent();
            this.ID.Text = id;
            this.lastName.Text = lastName;
            this.firstName.Text = firstName;
            this.middleName.Text = middleName;
            this.gender.Text = gender;
            this.phoneNumber.Text = phoneNumber;
        }

        private void btnClick_EditContact(object sender, RoutedEventArgs e)
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
                contactController.editContact(
                    lastName.Text.ToUpper(), 
                    firstName.Text.ToUpper(), 
                    middleName.Text.ToUpper(), 
                    gender.Text, 
                    phoneNumber.Text, 
                    ID.Text);
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
