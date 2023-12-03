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
using Dapper;

namespace _106LibrarySystem
{
    public partial class LoginPage : UserControl
    {
        HomeScreen memberHomePage = new HomeScreen();
        AdminHome adminHomePage = new AdminHome();
        SignUp signUp = new SignUp();

        public LoginPage()
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
            if (textBox.Text == "Password")
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
                textBox.Text = "Password";
                textBox.Foreground = Brushes.Gray;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = ItemBox.Text;
            string password = ItemBox2.Text;
            string databaseFileName = "LibraryDatabase.db";
            string source = $"Data Source={System.IO.Path.Combine(Directory.GetCurrentDirectory(), databaseFileName)}";



            using (IDbConnection connection = new SQLiteConnection(source))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM users WHERE userName = @userName AND password = @password";
                using (SQLiteCommand command = new SQLiteCommand(query, (SQLiteConnection)connection))
                {
                    command.Parameters.AddWithValue("@userName", username);
                    command.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Login Successful!");

                        string roleQuery = "SELECT role FROM users WHERE userName = @userName";
                        using (SQLiteCommand roleCommand = new SQLiteCommand(roleQuery, (SQLiteConnection)connection))
                        {
                            roleCommand.Parameters.AddWithValue("@userName", username);
                            string role = roleCommand.ExecuteScalar()?.ToString();

                            if (role == "Admin")
                            {
                                MessageBox.Show("You are logged in as an Admin.");
                                string userDetailsQuery = "SELECT * FROM users WHERE userName = @userName";
                                using (SQLiteCommand userDetailsCommand = new SQLiteCommand(userDetailsQuery, (SQLiteConnection)connection))
                                {
                                    userDetailsCommand.Parameters.AddWithValue("@userName", username);
                                    using (SQLiteDataReader reader = userDetailsCommand.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            User loggedInUser = new User
                                            {
                                                ID = Convert.ToInt32(reader["ID"]),
                                                FirstName = reader["firstName"].ToString(),
                                                JoinDate = reader["joinDate"].ToString(),
                                                PhoneNumber = reader["phoneNumber"].ToString(),
                                                EmailAddress = reader["emailAddress"].ToString()
                                            };
                                            adminHomePage.SetCurrentUser(loggedInUser);
                                            MainContent.Content = adminHomePage;
                                        }
                                    }
                                }
                            }
                            else if (role == "Member")
                            {
                                MessageBox.Show("You are logged in as a Member.");

                                string userDetailsQuery = "SELECT * FROM users WHERE userName = @userName";
                                using (SQLiteCommand userDetailsCommand = new SQLiteCommand(userDetailsQuery, (SQLiteConnection)connection))
                                {
                                    userDetailsCommand.Parameters.AddWithValue("@userName", username);
                                    using (SQLiteDataReader reader = userDetailsCommand.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            User loggedInUser = new User
                                            {
                                                ID = Convert.ToInt32(reader["ID"]),
                                                FirstName = reader["firstName"].ToString(),
                                                JoinDate = reader["joinDate"].ToString(),
                                                PhoneNumber = reader["phoneNumber"].ToString(),
                                                EmailAddress = reader["emailAddress"].ToString()
                                            };
                                            memberHomePage.SetCurrentUser(loggedInUser);
                                            MainContent.Content = memberHomePage;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Unknown role.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");
                    }
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainContent.Content = signUp;
        }
    }
}