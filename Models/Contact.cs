using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phonebook_desktop.Models
{
    internal class Contact
    {
        public static void createContact(string lastname, string firstname, string middlename, string gender, string phonenumber)
        {
            SqlConnection thisConnection = new SqlConnection(@"Server=.\sqlexpress;Database=Phonebook;Trusted_Connection=Yes;");
            try
            {
                thisConnection.Open();
                string query = $"EXEC usp_createSingleRecord '{lastname}', '{firstname}', '{middlename}', '{gender}', '{phonenumber}'";
                SqlCommand cmd = thisConnection.CreateCommand();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                thisConnection.Close();
            }
            catch
            {

            }
        }
        public static void editContact(string lastname, string firstname, string middlename, string gender, string phonenumber, int id)
        {
            SqlConnection thisConnection = new SqlConnection(@"Server=.\sqlexpress;Database=Phonebook;Trusted_Connection=Yes;");
            try
            {
                thisConnection.Open();
                string query = $"EXEC usp_createSingleRecord '{lastname}', '{firstname}', '{middlename}', '{gender}', '{phonenumber}', {id}";
                SqlCommand cmd = thisConnection.CreateCommand();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                thisConnection.Close();
            }
            catch
            {

            }
        }
        public static void deleteContact(int id)
        {
            SqlConnection thisConnection = new SqlConnection(@"Server=.\sqlexpress;Database=Phonebook;Trusted_Connection=Yes;");
            try
            {
                thisConnection.Open();
                string query = $"EXEC usp_DeleteRecords {id}";
                SqlCommand cmd = thisConnection.CreateCommand();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                thisConnection.Close();
            }
            catch
            {
                
            }
        }
    }
}
