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
    public class dbController
    {
        public void connectToDatabase(DataGrid contactslist)
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
    }
}
