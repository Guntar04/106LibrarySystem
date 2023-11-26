using Dapper;
using LibraryDatabase;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.IO;
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

namespace _106LibrarySystem
{
    public partial class AdminPage : UserControl
    {
    static string databaseFileName = "LibraryDatabase.db";
    static string source = $"Data Source={System.IO.Path.Combine(Directory.GetCurrentDirectory(), databaseFileName)}";

        public AdminPage()
        {
        InitializeComponent();
        DisplayUserData();
    }

        private void Log_Out(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            AdminContent.Content = loginPage;
        }

        private void DisplayUserData ()
    {
    using (IDbConnection connection = new SQLiteConnection (source))
    {
        connection.Open();
                var users = connection.Query ("SELECT * FROM users");

            userGrid.ItemsSource = users;
    }
}
}
}