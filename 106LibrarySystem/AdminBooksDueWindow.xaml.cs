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
    /// Interaction logic for AdminBooksDueWindow.xaml
    /// </summary>
    public partial class AdminBooksDueWindow : UserControl
    {
        static string databaseFileName = "LibraryDatabase.db";
        static string source = $"Data Source={System.IO.Path.Combine(Directory.GetCurrentDirectory(), databaseFileName)}";
        public AdminBooksDueWindow()
        {
            InitializeComponent();
            DisplayUserData();
        }
        private void DisplayUserData()
        {
            using (IDbConnection connection = new SQLiteConnection(source))
            {
                connection.Open();

                // Get the current date
                DateTime currentDate = DateTime.Now.Date;

                // Use a parameterized query to retrieve users with dueDates over the current date
                IEnumerable<dynamic> users = connection.Query("SELECT * FROM loanedBooks WHERE dueDate > @CurrentDate", new { CurrentDate = currentDate });

                userGrid.ItemsSource = users;
            }
        }
    }
}
