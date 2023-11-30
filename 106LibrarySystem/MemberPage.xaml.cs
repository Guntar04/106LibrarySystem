using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LibraryDatabase;

namespace _106LibrarySystem
{
    public partial class MemberPage : UserControl
    {
        public User currentUser;
        public List<loanedBooks> userBooks = new List<loanedBooks>();
        HomeScreen homeScreen = new HomeScreen();
        MemberBrowsing memberBrowsing = new MemberBrowsing();

        public MemberPage()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MemberContent.Content = homeScreen;
        }

        private void Catalogue_Click(object sender, RoutedEventArgs e)
        {
            MemberContent.Content = memberBrowsing;
        }

        private void Log_Out(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            MemberContent.Content = loginPage;
        }

        public void SetCurrentUser(User user)
        {
            currentUser = user;
            UpdateUserDetails();
            DisplayUserBooks(currentUser.ID);
        }

        private void UpdateUserDetails()
        {
            if (currentUser != null)
            {
                tbFirstname.Text = currentUser.FirstName;
                tbJoinDate.Text = currentUser.JoinDate;
                tbPhoneNumber.Text = currentUser.PhoneNumber;
                tbEmailAddress.Text = currentUser.EmailAddress;
                tbID.Text = currentUser.ID.ToString();
            }
        }

        private void GenerateBookImages()
        {
            // Clear existing images
            BookStackPanel.Children.Clear();

            if (userBooks != null)
            {
                Console.WriteLine($"Generating {userBooks.Count} book images.");

                foreach (loanedBooks book in userBooks)
                {
                    if (book.Book != null && !string.IsNullOrEmpty(book.Book.Name))
                    {
                        StackPanel bookPanel = new StackPanel
                        {
                            Orientation = Orientation.Vertical,
                            Margin = new Thickness(15)
                        };

                        TextBlock bookNameText = new TextBlock
                        {
                            Text = book.Book.Name,
                            Foreground = Brushes.White,
                            FontWeight = FontWeights.Bold,
                            Margin = new Thickness(0, 0, 0, 5)
                        };

                        TextBlock dueDateText = new TextBlock
                        {
                            Text = $"Due Date: {book.dueDate.ToShortDateString()}",
                            Foreground = Brushes.White,
                            FontStyle = FontStyles.Italic
                        };

                        bookPanel.Children.Add(bookNameText);
                        bookPanel.Children.Add(dueDateText);

                        BookStackPanel.Children.Add(bookPanel);
                    }
                    else
                    {
                        Console.WriteLine($"Skipping book {book.bookID} due to null or empty bookName.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No user books found.");
            }
        }

        public void DisplayUserBooks(int userID)
        {
            try
            {
                userBooks.Clear();

                string databaseFileName = "LibraryDatabase.db";
                string source = $"Data Source={Path.Combine(Directory.GetCurrentDirectory(), databaseFileName)}";

                using (IDbConnection connection = new SQLiteConnection(source))
                {
                    connection.Open();

                    string query = @"
                        SELECT lb.*, b.name AS bookName
                        FROM loanedBooks lb
                        INNER JOIN books b ON lb.bookID = b.ID
                        WHERE lb.userID = @userID AND (lb.loanStatus = 'Loaned' OR lb.loanStatus = 'Overdue')
                    ";

                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = query;

                        IDbDataParameter parameter = command.CreateParameter();
                        parameter.ParameterName = "@userID";
                        parameter.Value = userID;
                        command.Parameters.Add(parameter);

                        using (IDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                loanedBooks book = new loanedBooks
                                {
                                    bookID = Convert.ToInt32(reader["bookID"]),
                                    userID = Convert.ToInt32(reader["userID"]),
                                    loanDate = Convert.ToDateTime(reader["loanDate"]),
                                    dueDate = Convert.ToDateTime(reader["dueDate"]),
                                    returnDate = reader["returnDate"] != DBNull.Value ? Convert.ToDateTime(reader["returnDate"]) : (DateTime?)null,
                                    loanStatus = reader["loanStatus"].ToString(),
                                    Book = new Book { Name = reader["bookName"].ToString() }
                                };

                                userBooks.Add(book);
                            }
                        }
                    }

                    // Log the count of userBooks after retrieval
                    Console.WriteLine($"UserID: {userID}, UserBooks Count: {userBooks.Count}");
                }

                // Generate and display book images
                GenerateBookImages();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in DisplayUserBooks: {ex.Message}");
            }
        }
    }
}
