using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HomeScreen homePage = new HomeScreen();
        SignUp signUp = new SignUp();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = ItemBox.Text;
            string password = ItemBox2.Text;
            string databaseFileName = "LibraryDatabase.db";
            string source = $"Data Source={System.IO.Path.Combine(Directory.GetCurrentDirectory(), databaseFileName)}";

            // Establish a connection with the SQLite database
            using (IDbConnection connection = new SQLiteConnection(source))
            {
                connection.Open();

                // Query the database for a user with the entered username and password
                string query = "SELECT COUNT(*) FROM users WHERE userName = @userName AND password = @password";
                using (SQLiteCommand command = new SQLiteCommand(query, (SQLiteConnection)connection))
                {
                    command.Parameters.AddWithValue("@userName", username);
                    command.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        // User authenticated, grant access to the application
                        MessageBox.Show("Login Successful!");
                        MainContent.Content = homePage;
                    }
                    else
                    {
                        // Show an error message indicating invalid credentials
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
