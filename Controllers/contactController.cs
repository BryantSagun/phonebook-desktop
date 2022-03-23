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
    public class contactController
    {
        public static DataTable getContacts()
        {
            dbController dbc = new dbController();
            return dbc.getContacts();
        }
        public static void createContact(string lastname, string firstname, string middlename, string gender, string phonenumber)
        {
            dbController dbc = new dbController();
            dbc.createNewContact(lastname, firstname, middlename, gender, phonenumber);
        }
        public static void editContact(string lastname, string firstname, string middlename, string gender, string phonenumber, string id)
        {
            dbController dbc = new dbController();
            dbc.editContact(lastname, firstname, middlename, gender, phonenumber, id);
        }
        public static void deleteContact(string id)
        {
            dbController dbc = new dbController();
            dbc.deleteContact(id);
        }

        public static Boolean checkValidString(string data)
        {
            Boolean result = false;
            if (!String.IsNullOrEmpty(data) & 
                !(data.Trim().Length == 0)) result = true;
            return result;
        }

        public static Boolean checkIfStringIsNumeric(string data)
        {
            double number;
            return double.TryParse(data, out number);
        }
    }
}
