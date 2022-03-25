using phonebook_desktop.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace phonebook_desktop.Views.confirmationBoxes
{
    /// <summary>
    /// Interaction logic for DeletetRecordConfirmationBox.xaml
    /// </summary>
    public partial class DeleteRecordConfirmationBox : Window
    {
        dbController dbc = new dbController();
        public DeleteRecordConfirmationBox(string lastname, string firstname)
        {
            InitializeComponent();
            DCBPromptMsg.Content = $"Delete {firstname} {lastname} from contacts?";
        }

        private void CloseDBCWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void confirmDeleteBtn(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
