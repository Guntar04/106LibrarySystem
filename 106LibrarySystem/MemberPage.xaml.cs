using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using LibraryDatabase;
using System.Windows.Media.Imaging;

namespace _106LibrarySystem
{
    public partial class MemberPage : UserControl
    {
        public User currentUser;
        public List<Loans> userBooks = new List<Loans>();
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
            if (currentUser != null)
            {
                DisplayUserBooks(currentUser.ID);
            }

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
        public void DisplayUserBooks(int userID)
        {
            userBooks.Clear();

                string databaseFileName = "LibraryDatabase.db";
                string source = $"Data Source={Path.Combine(Directory.GetCurrentDirectory(), databaseFileName)}";

                using (IDbConnection connection = new SQLiteConnection(source))
                {
                    connection.Open();

                    string query = @"
                        SELECT lb.*, b.name AS bookName, b.ImagePath AS bookImagePath
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
                                Loans book = new Loans
                                {
                                    bookID = Convert.ToInt32(reader["bookID"]),
                                    userID = Convert.ToInt32(reader["userID"]),
                                    loanDate = Convert.ToDateTime(reader["loanDate"]),
                                    dueDate = Convert.ToDateTime(reader["dueDate"]),
                                    returnDate = reader["returnDate"] != DBNull.Value ? Convert.ToDateTime(reader["returnDate"]) : (DateTime?)null,
                                    loanStatus = reader["loanStatus"].ToString(),
                                    Book = new Book
                                    {
                                        Name = reader["bookName"].ToString(),
                                        ImagePath = reader["bookImagePath"].ToString()
                                    }
                                };
                                userBooks.Add(book);
                            }
                        }
                    }
                }
            GenerateBookImages();
        }
        private void GenerateBookImages()
        {
            BookStackPanel.Items.Clear();

            if (userBooks != null)
            {
                foreach (Loans book in userBooks)
                {
                    if (book.Book != null && !string.IsNullOrEmpty(book.Book.Name))
                    {
                        BitmapImage image = null;

                        if (!string.IsNullOrEmpty(book.Book.ImagePath) && File.Exists(book.Book.ImagePath))
                        {
                            image = new BitmapImage(new Uri(book.Book.ImagePath));
                        }

                        Button bookButton = new Button
                        {
                            Content = new StackPanel
                            {
                                Orientation = Orientation.Vertical,
                                Children =
                        {
                            new Image
                            {
                                Source = image,
                                Height = 180,
                                Width = 160,
                                Margin = new Thickness(0, 0, 0, 5)
                            },
                            new TextBlock
                            {
                                Text = book.Book.Name,
                                Foreground = System.Windows.Media.Brushes.White,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                FontWeight = FontWeights.Bold,
                                Margin = new Thickness(0, 0, 0, 5)
                            },
                            new TextBlock
                            {
                                Text = $"Due Date: {book.dueDate.ToShortDateString()}",
                                Foreground = System.Windows.Media.Brushes.White,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                FontStyle = FontStyles.Italic
                            }
                        }
                            }
                        };

                        BookStackPanel.Items.Add(bookButton);
                    }
                }
            }
        }
    }
}