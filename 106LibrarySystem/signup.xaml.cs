using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Remoting.Contexts;
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
using Dapper;

namespace _106LibrarySystem
{
    public partial class SignUp : UserControl
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void Back_To_Login(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            SignInContent.Content = loginPage;
        }

        private void Created_Account(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            string username = ItemBox.Text;
            string firstName = ItemBox2.Text;
            string lastName = ItemBox3.Text;
            string emailAddress = ItemBox4.Text;
            string phoneNumber = ItemBox5.Text;
            string password = ItemBox6.Text;
            string databaseFileName = "LibraryDatabase.db";
            string source = $"Data Source={System.IO.Path.Combine(Directory.GetCurrentDirectory(), databaseFileName)}";

            using (IDbConnection connection = new SQLiteConnection(source))
            {
                connection.Open();
                connection.Execute(
                    "INSERT INTO users (userName, firstName, lastName, emailAddress, phoneNumber, password, role) " +
                    "VALUES (@UserName, @FirstName, @LastName, @EmailAddress, @PhoneNumber, @Password, @Role)",
                    new
                    {
                        UserName = username,
                        FirstName = firstName,
                        LastName = lastName,
                        EmailAddress = emailAddress,
                        PhoneNumber = phoneNumber,
                        Password = password,
                        Role = "Member"
                    });

                MessageBox.Show("Sign Up Successful!");
                SignInContent.Content = loginPage;
            }
        }
    }
}