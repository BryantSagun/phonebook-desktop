using phonebook_desktop.Controllers;
using phonebook_desktop.Models;
using phonebook_desktop.Views;
using phonebook_desktop.Views.confirmationBoxes;
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
            refreshContactslist();
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
            string lastName = row["LastName"].ToString();
            string firstName = row["FirstName"].ToString();
            string middleName = row["MiddleName"].ToString();
            string gender = row["Gender"].ToString();
            string phoneNumber = row["PhoneNumber"].ToString();
            string id = row["ID"].ToString();
            
            Edit editContact = new Edit(lastName, firstName, middleName, gender, phoneNumber, id);
            this.Close();
            editContact.Show();
        }

        private void btnClick_DeleteContact(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)contactslist.SelectedItem;
            string lastName = row["LastName"].ToString();
            string firstName = row["FirstName"].ToString();
            string id = row["ID"].ToString();
            DeleteRecordConfirmationBox dcb = new DeleteRecordConfirmationBox(lastName, firstName);
            if (dcb.ShowDialog() == true)
            {
                contactController.deleteContact(id);
                refreshContactslist();
            }
        }

        private void filterContacts(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(searchContact.Text) | searchContact.Text.Trim().Length == 0)
            {
                contactslist.ItemsSource = contactController.getContacts().DefaultView;
            }
            else
            {
                contactslist.ItemsSource = contactController.getFilteredContacts(searchContact.Text).DefaultView;
            }
            contactslist.Items.Refresh();
        }

        private void refreshContactslist()
        {
            contactslist.ItemsSource = contactController.getContacts().DefaultView;
            contactslist.Items.Refresh();
        }
    }
}
