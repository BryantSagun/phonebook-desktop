using phonebook_desktop.Controllers;
using phonebook_desktop.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace phonebook_desktop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            contactController.getContacts(contactslist);
            contactslist.Items.Refresh();
            contactslist.Columns[2].Visibility = Visibility.Collapsed;
        }

        private void btnClick_AddContact(object sender, RoutedEventArgs e)
        {
            Create createNewContactWindow = new Create();
            this.Close();
            createNewContactWindow.Show();
        }

        private void btnClick_EditContact(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)contactslist.SelectedItem;
            string lastName = row.Row["lastName"] as string;
            string firstName = row.Row["firstName"] as string;
            string middleName = row.Row["middleName"] as string;
            string gender = row.Row["gender"] as string;
            string phoneNumber = row.Row["phoneNumber"] as string;
            Edit editContact = new Edit(lastName, firstName, middleName, gender, phoneNumber);
            this.Close();
            editContact.Show();
        }

        private void btnClick_DeleteContact(object sender, RoutedEventArgs e)
        {
            contactController.deleteContact(12);
            contactslist.ItemsSource = null;
            contactController.getContacts(contactslist);
        }
    }
}
