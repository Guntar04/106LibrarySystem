using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Dapper;
using System.IO;

namespace _106LibrarySystem
{
    /// <summary>
    /// Interaction logic for AdminLoanedBooksWindow.xaml
    /// </summary>
    public partial class AdminLoanedBooksWindow : UserControl
    {
        static string databaseFileName = "LibraryDatabase.db";
        static string source = $"Data Source={System.IO.Path.Combine(Directory.GetCurrentDirectory(), databaseFileName)}";
        public AdminLoanedBooksWindow()
        {
            InitializeComponent();
            DisplayUserData();
        }
        private void DisplayUserData()
        {
            string Loaned = "Loaned";
            using (IDbConnection connection = new SQLiteConnection(source))
            {
                connection.Open();

                // Use a parameterized query to retrieve users with dueDates over the current date
                IEnumerable<dynamic> users = connection.Query("SELECT * FROM loanedBooks WHERE loanStatus = @LoanStatus", new { LoanStatus = Loaned });

                userGrid.ItemsSource = users;
            }
        }
    }
}
