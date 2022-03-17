using phonebook_desktop.Controllers;
using phonebook_desktop.Models;
using phonebook_desktop.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        dbController dbc = new dbController();
        public MainWindow()
        {
            InitializeComponent();
            contactslist.ItemsSource = contactController.getContacts().DefaultView;
            contactslist.Items.Refresh();
        }

        private void btnClick_AddContact(object sender, RoutedEventArgs e)
        {
            Create createNewContactWindow = new Create();
            this.Close();
            createNewContactWindow.Show();
        }

        private void btnClick_EditContact(object sender, RoutedEventArgs e)
        {
            string lastName = "";
            string firstName = "";
            string middleName = "";
            string gender = "";
            string phoneNumber = "";
            
            Edit editContact = new Edit(lastName, firstName, middleName, gender, phoneNumber);
            this.Close();
            editContact.Show();
        }

        private void btnClick_DeleteContact(object sender, RoutedEventArgs e)
        {
            contactController.deleteContact(15);
            DataTable records = dbc.getContacts();
            contactslist.ItemsSource = records.DefaultView;
            contactslist.Items.Refresh();
        }
    }
}
