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
            DataContext = typeof(User);
        }

        private void Log_Out(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            AdminContent.Content = loginPage;
        }

        private void User_List(object sender, RoutedEventArgs e)
        {
            AdminUserList userList = new AdminUserList();
            AdminDetails.Content = userList;
        }
        private void Books_Due(object sender, RoutedEventArgs e)
        {
            AdminBooksDueWindow booksDue = new AdminBooksDueWindow();
            AdminDetails.Content = booksDue;
        }
        private void Books_Loaned(object sender, RoutedEventArgs e)
        {
            AdminLoanedBooksWindow loanedBooks = new AdminLoanedBooksWindow();
            AdminDetails.Content = loanedBooks;
        }
        private void Home_Page(object sender, RoutedEventArgs e)
        {
            AdminHome adminHome = new AdminHome();
            AdminContent.Content = adminHome;
        }
        private void Catalouge_Page(object sender, RoutedEventArgs e)
        {
            AdminBrowsing adminBrowsing = new AdminBrowsing();
            AdminContent.Content = adminBrowsing;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            AdminContent.Content = adminPage;
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