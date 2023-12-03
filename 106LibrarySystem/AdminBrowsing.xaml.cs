using _106LibrarySystem;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
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
using System.IO;
using Dapper;

namespace LibraryDatabase
{
    /// <summary>
    /// Interaction logic for MemberBrowsing.xaml
    /// </summary>
    public partial class AdminBrowsing : UserControl
    {
        private string databaseFileName = "LibraryDatabase.db";
        private string source;
        private User currentUser;

        public AdminBrowsing()
        {
            InitializeComponent();
            var bookViewModel = new BookViewModel();
            DataContext = bookViewModel;
            AdminBrowsingContent.DataContext = bookViewModel;
            source = $"Data Source={System.IO.Path.Combine(Directory.GetCurrentDirectory(), databaseFileName)}";
        }

        private void Home_Admin(object sender, RoutedEventArgs e)
        {
            AdminHome adminHome = new AdminHome();
            AdminBrowsingContent.Content = adminHome;
        }
        private void Profile_Admin(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            AdminBrowsingContent.Content = adminPage;
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            AddBookWindow addBookWindow = new AddBookWindow((BookViewModel)DataContext);
            addBookWindow.Owner = Window.GetWindow(this); // Set the owner to enable proper interaction
            addBookWindow.ShowDialog(); // Show the window as a modal dialog
        }

        private void EditCatalogueButton_Click(object sender, RoutedEventArgs e)
        {
            EditCatalogueWindow editCatalogueWindow = new EditCatalogueWindow((BookViewModel)DataContext);
            editCatalogueWindow.Owner = Window.GetWindow(this);
            editCatalogueWindow.ShowDialog();
        }

        private void RemoveBook_Click(object sender, RoutedEventArgs e)
        {
            // Show a confirmation dialog
            MessageBoxResult result = MessageBox.Show("Are you sure you want to remove this book?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // If user clicks Yes, remove the book
            if (result == MessageBoxResult.Yes)
            {
                // Get the book associated with the clicked button
                BookViewModel bookViewModel = (BookViewModel)DataContext;
                Book bookToRemove = ((Button)sender).DataContext as Book;

                if (bookToRemove != null)
                {
                    // Remove the book from the database and UI
                    bookViewModel.RemoveBook(bookToRemove);
                }
            }

        }

        private void ToggleRemoveButtons_Click(object sender, RoutedEventArgs e)
        {
            BookViewModel bookViewModel = (BookViewModel)DataContext;

            // Toggle the visibility of "Remove Book" buttons
            bookViewModel.IsRemoveButtonVisible = !bookViewModel.IsRemoveButtonVisible;
        }

        private void Image_Click(object sender, MouseButtonEventArgs e)
        {
            using (IDbConnection connection = new SQLiteConnection(source))
            {
                connection.Open();
                string bookID = (string)((Image)sender).Tag;
                string query = "SELECT * FROM books WHERE Id = @BookID";
                var book = connection.QueryFirstOrDefault<Book>(query, new { BookID = bookID });

                if (book != null)
                {
                    int id = book.Id;
                    string name = book.name;
                    string author = book.author;
                    string genre = book.genre;
                    int availability = book.availability;
                    string language = book.language;
                    int pageNum = book.pageNum;
                    int date = book.date;
                    string imagePath = book.ImagePath;
                    string description = book.description;

                    Book selectedBook = new Book
                    {
                        Id = id,
                        name = name,
                        author = author,
                        genre = genre,
                        availability = availability,
                        language = language,
                        pageNum = pageNum,
                        date = date,
                        ImagePath = imagePath,
                        description = description
                    };

                    // Pass the currentUser to the constructor of MemberBookDetail
                    AdminBookDetail adminBookDetail = new AdminBookDetail(selectedBook, currentUser);

                    AdminBrowsingContent.Content = adminBookDetail;
                }
                else
                {
                    MessageBox.Show("Book not found in the database.");
                }
            }
        }
    }
}
