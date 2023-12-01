using System;
using System.Collections.Generic;
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
using _106LibrarySystem;
using System.Xml.Linq;
using LibraryDatabase;
using System.Data;
using System.Net.Mail;
using System.IO;
using System.Data.SQLite;
using Dapper;

namespace _106LibrarySystem
{
    public partial class HomeScreen : UserControl
    {
        private string databaseFileName = "LibraryDatabase.db";
        private string source;
        private BookViewModel bookViewModel;


        public HomeScreen()
        {
            InitializeComponent();
            source = $"Data Source={System.IO.Path.Combine(Directory.GetCurrentDirectory(), databaseFileName)}";

            bookViewModel = new BookViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MemberPage memberPage = new MemberPage();
            memberPage.SetCurrentUser(currentUser);
            HomeContent.Content = memberPage;

           
        }

        private void Image_Click(object sender, MouseButtonEventArgs e)
        {
            using (IDbConnection connection = new SQLiteConnection(source))
            {
                connection.Open();
                string bookName = (string)((Image)sender).Tag;
                string query = "SELECT * FROM books WHERE name = @BookName";
                var book = connection.QueryFirstOrDefault<Book>(query, new { BookName = bookName });

                if (book != null)
                {
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
                    MemberBookDetail memberBookDetail = new MemberBookDetail(selectedBook, currentUser);

                    HomeContent.Content = memberBookDetail;
                }
                else
                {
                    MessageBox.Show("Book not found in the database.");
                }
            }
        }
        private void Catalogue_Click(object sender, RoutedEventArgs e)
        {
            MemberBrowsing memberBrowsing = new MemberBrowsing();
            HomeContent.Content = memberBrowsing;
        }
        public User currentUser;
        public void SetCurrentUser(User user)
        {
            currentUser = user;
        }
    }
}