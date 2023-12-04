using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using LibraryDatabase;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace _106LibrarySystem
{
    public partial class MemberPage : UserControl
    {
        public List<Book> userBooks = new List<Book>();
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

            foreach (Book currentBook in userBooks)
            {
                if (currentBook != null && !string.IsNullOrEmpty(currentBook.name))
                {
                    StackPanel bookPanel = new StackPanel
                    {
                        Orientation = Orientation.Vertical,
                        Margin = new Thickness(15)
                    };

                    TextBlock bookNameText = new TextBlock
                    {
                        Text = currentBook.name,
                        Foreground = Brushes.White,
                        FontWeight = FontWeights.Bold,
                        Margin = new Thickness(0, 0, 0, 5)
                    };

                    TextBlock dueDateText = new TextBlock
                    {
                        Text = $"Due Date: {currentBook.dueDate.ToString("dd/MM/yyyy")}",
                        Foreground = Brushes.White,
                        FontStyle = FontStyles.Italic
                    };
                    Book = currentBook;

                    if (!string.IsNullOrEmpty(currentBook._imagePath))
                    {
                        string imagePath = currentBook._imagePath;

                        BitmapImage image = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));

                        // Create an Image control to display the loaded image
                        Image bookImage = new Image
                        {
                            Source = image,
                            Width = 100, // Set the width as needed
                            Height = 150, // Set the height as needed
                            Margin = new Thickness(0, 5, 0, 0) // Adjust margin as needed
                        };

                        bookPanel.Children.Add(bookImage); // Add the Image control here
                        bookPanel.Children.Add(bookNameText);
                        bookPanel.Children.Add(dueDateText);
                        BookStackPanel.Children.Add(bookPanel);
                    }
                }
            }
        }

        public LibraryDatabase.Book Book
        {
            get { return (LibraryDatabase.Book)GetValue(BookProperty); }
            set { SetValue(BookProperty, value); }
        }

        public static readonly DependencyProperty BookProperty =
            DependencyProperty.Register("Book", typeof(LibraryDatabase.Book), typeof(MemberPage), new PropertyMetadata(null));

        public void DisplayUserBooks(int userID)
        {
            string databaseFileName = "LibraryDatabase.db";
            string source = $"Data Source={Path.Combine(Directory.GetCurrentDirectory(), databaseFileName)}";

            using (IDbConnection connection = new SQLiteConnection(source))
            {
                connection.Open();

                string query = @"
                SELECT lb.*, b.name AS bookName, b.ImagePath
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
                            Book book = new Book
                            {
                                bookID = Convert.ToInt32(reader["bookID"]),
                                userID = Convert.ToInt32(reader["userID"]),
                                loanStatus = reader["loanStatus"].ToString(),
                                name = reader["bookName"].ToString(),
                                ImagePath = reader["ImagePath"].ToString()
                            };

                            userBooks.Add(book);
                        }
                    }
                }
            }
            // Generate and display book images
            GenerateBookImages();
        }

        public void SetCurrentUser(User user)
        {
            currentUser = user;

            // Check if currentUser is null
            if (currentUser != null)
            {
                // Update user details when currentUser is set
                UpdateUserDetails();
                DisplayUserBooks(currentUser.ID);
            }
            else
            {
                // Handle the case where currentUser is null
                MessageBox.Show("Current user is null.");
            }
        }
        public static User currentUser;
    }
}