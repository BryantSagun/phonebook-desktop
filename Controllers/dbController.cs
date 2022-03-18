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
    public class dbController : Contact
    {
        SqlConnection thisConnection = new SqlConnection(@"Server=.\sqlexpress;Database=Phonebook;Trusted_Connection=Yes;");
        string query = "";

        public void connectToDatabase(DataGrid contactslist)
        {
            try
            {
                thisConnection.Open();
            }
            catch
            {

            }   
        }
        public DataTable getContacts()
        {
            query = "EXEC usp_ReadRecords";
            SqlCommand cmd = thisConnection.CreateCommand();
            executeQuery(query, cmd);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("ContactDetails");
            sda.Fill(dt);
            return dt;
        }
        public void createNewContact(string lastname, string firstname, string middlename, string gender, string phonenumber)
        {
            query = $"EXEC usp_createSingleRecord '{lastname}', '{firstname}', '{middlename}', '{gender}', '{phonenumber}'";
            SqlCommand cmd = thisConnection.CreateCommand();
            executeQuery(query, cmd);
        }
        public void deleteContact(string id)
        {
            query = $"EXEC usp_DeleteRecords {id}";
            SqlCommand cmd = thisConnection.CreateCommand();
            executeQuery(query, cmd);
        }
        public void editContact(string lastname, string firstname, string middlename, string gender, string phonenumber, string id)
        {
            query = $"EXEC usp_UpdateSingleRecord '{lastname}', '{firstname}', '{middlename}', '{gender}', '{phonenumber}', '{id}'";
            SqlCommand cmd = thisConnection.CreateCommand();
            executeQuery(query, cmd);
        }
        private void executeQuery(string query, SqlCommand cmd)
        {
            thisConnection.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            thisConnection.Close();
        }
    }
}
