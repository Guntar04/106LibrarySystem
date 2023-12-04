using LibraryDatabase;
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
using Dapper;
using System.IO;

namespace _106LibrarySystem
{
    /// <summary>
    /// Interaction logic for AdminHome.xaml
    /// </summary>
    public partial class AdminHome : UserControl
    {
        private string databaseFileName = "LibraryDatabase.db";
        private string source;
        private static User currentUser;

        public AdminHome()
        {
            InitializeComponent();
            source = $"Data Source={System.IO.Path.Combine(Directory.GetCurrentDirectory(), databaseFileName)}";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            adminPage.UpdateUserDetails(currentUser);
            AdminHomeContent.Content = adminPage;
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

                    AdminBookDetail adminBookDetail = new AdminBookDetail(selectedBook, currentUser);
                    adminBookDetail.SetCurrentUser(currentUser);
                    AdminHomeContent.Content = adminBookDetail;
                }
                else
                {
                    MessageBox.Show("Book not found in the database.");
                }
            }
        }
        private void Catalouge_Admin(object sender, RoutedEventArgs e)
        {
            AdminBrowsing adminBrowsing = new AdminBrowsing();
            adminBrowsing.SetCurrentUser(currentUser);
            AdminHomeContent.Content = adminBrowsing;
        }
        public void SetCurrentUser(User user)
        {
            currentUser = user;
        }
    }
}
