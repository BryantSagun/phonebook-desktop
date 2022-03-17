using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phonebook_desktop.Models
{
    public class Contact
    {
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string gender { get; set; }
        public string phonenumber { get; set; }
    }
}
