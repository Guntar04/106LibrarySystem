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
        private void ItemBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Username")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }
        private void ItemBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "Username";
                textBox.Foreground = Brushes.Gray;
            }
        }
        private void ItemBox2_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "First Name")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }
        private void ItemBox2_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "First Name";
                textBox.Foreground = Brushes.Gray;
            }
        }
        private void ItemBox3_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Last Name")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }
        private void ItemBox3_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "Last Name";
                textBox.Foreground = Brushes.Gray;
            }
        }
        private void ItemBox4_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Email Address")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }
        private void ItemBox4_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "Email Address";
                textBox.Foreground = Brushes.Gray;
            }
        }
        private void ItemBox5_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Phone Number")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }
        private void ItemBox5_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "Phone Number";
                textBox.Foreground = Brushes.Gray;
            }
        }
        private void ItemBox6_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Password")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }
        private void ItemBox6_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "Password";
                textBox.Foreground = Brushes.Gray;
            }
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

            // Check if any of the required textboxes are empty
            if(string.IsNullOrEmpty(username) || username == "Username" ||
               string.IsNullOrEmpty(firstName) || firstName == "First Name" ||
               string.IsNullOrEmpty(lastName) || lastName == "Last Name" ||
               string.IsNullOrEmpty(emailAddress) || emailAddress == "Email Address" ||
               string.IsNullOrEmpty(phoneNumber) || phoneNumber == "Phone Number" ||
               string.IsNullOrEmpty(password) || password == "Password")
            {
                MessageBox.Show("Please fill in all the required fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return; // Exit the method without appending the data
            }

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