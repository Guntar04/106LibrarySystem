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
using System.Net.Mail;
using System.ComponentModel;

namespace _106LibrarySystem
{
    public partial class AdminPage : UserControl
    {
        private static readonly string databaseFileName = "LibraryDatabase.db";
        private static readonly string source = $"Data Source={System.IO.Path.Combine(Directory.GetCurrentDirectory(), databaseFileName)}";
        private int currentUserID;

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
        private void DisplayUserData()
        {
            using (IDbConnection connection = new SQLiteConnection(source))
            {
                connection.Open();
                var users = connection.Query("SELECT * FROM users");
                userGrid.ItemsSource = users;
            }
        }
        private void Add_User(object sender, RoutedEventArgs e)
        {
            AddUserPopup.IsOpen = true;
        }

        private void SaveUser_Click(object sender, RoutedEventArgs e)
        {
            string userName = UserName.Text;
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            string emailAddress = EmailAddress.Text;
            string phoneNumber = PhoneNumber.Text;
            string password = Password.Text;
            string role = Role.Text;
            DateTime joinDate = DateTime.Today;
            string formattedJoinDate = joinDate.ToString("dd/MM/yyyy");
            int booksLoaned = 0;
            int overDueBooks = 0;
            using (IDbConnection connection = new SQLiteConnection(source))
            {
                connection.Open();
                int nextID = connection.ExecuteScalar<int>("SELECT COALESCE(MAX(ID), 0) + 1 FROM users");
                string insertQuery = @"
                INSERT INTO users
                (UserName, FirstName, LastName, EmailAddress, PhoneNumber, Password, Role, ID, JoinDate, BooksLoaned, OverDueBooks)
                VALUES (@UserName, @FirstName, @LastName, @EmailAddress, @PhoneNumber, @Password, @Role, @ID, @JoinDate, @BooksLoaned, @OverDueBooks)";
                connection.Execute(insertQuery, new
                {
                    UserName = userName,
                    FirstName = firstName,
                    LastName = lastName,
                    EmailAddress = emailAddress,
                    PhoneNumber = phoneNumber,
                    Password = password,
                    Role = role,
                    ID = nextID,
                    JoinDate = formattedJoinDate,
                    BooksLoaned = booksLoaned,
                    OverDueBooks = overDueBooks
                });
            }
            AddUserPopup.IsOpen = false;
            DisplayUserData();
        }
        private void Edit_User(object sender, RoutedEventArgs e)
        {
            EditUserIDPopup.IsOpen = true;
        }

        private void EditUserIDOK_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(UserIDTextBox.Text, out currentUserID))
            {
                EditUserIDPopup.IsOpen = false;
                PopulateEditUserPopup(currentUserID);
                EditUserPopup.IsOpen = true;
            }
            else
            {
                MessageBox.Show("Invalid User ID. Please enter a valid number.");
            }
        }

        private void PopulateEditUserPopup(int userID)
        {
            User user = DatabaseHelper.GetUserByID(userID);

            if (user != null)
            {
                // Update the TextBoxes in EditUserPopup with the fetched details
                UserName1.Text = user.UserName;
                FirstName1.Text = user.FirstName;
                LastName1.Text = user.LastName;
                EmailAddress1.Text = user.EmailAddress;
                PhoneNumber1.Text = user.PhoneNumber;
                Password1.Text = user.Password;
                Role1.Text = user.Role;
            }
            else
            {
                // Handle the case where the user with the specified ID is not found
                MessageBox.Show("User not found in the database.");
            }
        }

        private void UpdateUser_Click(object sender, RoutedEventArgs e)
        {
            // Get the updated user details from EditUserPopup
            User updatedUser = new User
            {
                ID = currentUserID,
                UserName = UserName1.Text,
                FirstName = FirstName1.Text,
                LastName = LastName1.Text,
                EmailAddress = EmailAddress1.Text,
                PhoneNumber = PhoneNumber1.Text,
                Password = Password1.Text,
                Role = Role1.Text
            };

            // Update the user in the database
            DatabaseHelper.UpdateUser(updatedUser);

            // Close the EditUserPopup
            EditUserPopup.IsOpen = false;

            // Refresh the user data grid or perform any necessary updates
            DisplayUserData();
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
        private void ItemBox_GotFocus2(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "First Name")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }
        private void ItemBox_LostFocus2(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "First Name";
                textBox.Foreground = Brushes.Gray;
            }
        }
        private void ItemBox_GotFocus3(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Last Name")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }
        private void ItemBox_LostFocus3(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "Last Name";
                textBox.Foreground = Brushes.Gray;
            }
        }
        private void ItemBox_GotFocus4(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Email Address")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }
        private void ItemBox_LostFocus4(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "Email Address";
                textBox.Foreground = Brushes.Gray;
            }
        }
        private void ItemBox_GotFocus5(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Phonenumber")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }
        private void ItemBox_LostFocus5(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "Phonenumber";
                textBox.Foreground = Brushes.Gray;
            }
        }
        private void ItemBox_GotFocus6(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Password")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }
        private void ItemBox_LostFocus6(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "Password";
                textBox.Foreground = Brushes.Gray;
            }
        }
        private void ItemBox_GotFocus7(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "User's Role")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }
        private void ItemBox_LostFocus7(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "User's Role";
                textBox.Foreground = Brushes.Gray;
            }
        }
    }
}