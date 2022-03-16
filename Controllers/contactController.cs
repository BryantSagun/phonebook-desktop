using phonebook_desktop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace phonebook_desktop.Controllers
{
    internal class contactController
    {
        public static void getContacts(DataGrid contactslist)
        {
            SqlConnection thisConnection = new SqlConnection(@"Server=.\sqlexpress;Database=Phonebook;Trusted_Connection=Yes;");
            try
            {
                thisConnection.Open();
                string query = "EXEC usp_ReadRecords";

                SqlCommand cmd = thisConnection.CreateCommand();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                thisConnection.Close();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("ContactDetails");
                sda.Fill(dt);
                contactslist.ItemsSource = dt.DefaultView;
            }
            catch
            {

            }
        }
        public static void createContact(string lastname, string firstname, string middlename, string gender, string phonenumber)
        {
            Contact.createContact(lastname, firstname, middlename, gender, phonenumber);
        }
        public static void editContact(string lastname, string firstname, string middlename, string gender, string phonenumber, int id)
        {
            Contact.editContact(lastname, firstname, middlename, gender, phonenumber, id);
        }
        public static void deleteContact(int id)
        {
            Contact.deleteContact(id);
        }
    }
}
