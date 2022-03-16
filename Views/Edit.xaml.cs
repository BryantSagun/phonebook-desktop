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

namespace phonebook_desktop.Views
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        public Edit(string lastName, string firstName, string middleName, string gender, string phoneNumber)
        {
            InitializeComponent();
            this.lastName.Text = lastName;
            this.firstName.Text = firstName;
            this.middleName.Text = middleName;
            this.gender.SelectedIndex = 1;
            this.phoneNumber.Text = phoneNumber;
        }

        private void btnClick_EditContact(object sender, RoutedEventArgs e)
        {

        }

        private void btnClick_BackToHome(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}
