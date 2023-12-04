using _106LibrarySystem;
using System.Data.SQLite;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Dapper;
using System.IO;

namespace LibraryDatabase
{
    /// <summary>
    /// Interaction logic for MemberBrowsing.xaml
    /// </summary>
    public partial class MemberBrowsing : UserControl
    {
        private string databaseFileName = "LibraryDatabase.db";
        private string source;
        private static User currentUser;
        public MemberBrowsing()
        {
            InitializeComponent();
            var bookViewModel = new BookViewModel();
            DataContext = bookViewModel;
            MemberBrowse.DataContext = bookViewModel;
            source = $"Data Source={System.IO.Path.Combine(Directory.GetCurrentDirectory(), databaseFileName)}";
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            HomeScreen homeScreen = new HomeScreen();
            MemberBrowse.Content = homeScreen;
        }
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            MemberPage memberPage = new MemberPage();
            //memberPage.SetCurrentUser(currentUser);
            MemberBrowse.Content = memberPage;
        }
        private void Image_Click(object sender, MouseButtonEventArgs e)
        {
            using (IDbConnection connection = new SQLiteConnection(source))
            {
                connection.Open();
                int bookID = (int)((Image)sender).Tag;
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
                    MemberBookDetail memberBookDetail = new MemberBookDetail(selectedBook, currentUser);
                    memberBookDetail.SetCurrentUser(currentUser);
                    MemberBrowse.Content = memberBookDetail;
                }
                else
                {
                    MessageBox.Show("Book not found in the database.");
                }
            }
        }
        public void SetCurrentUser(User user)
        {
            currentUser = user;
        }
    }
}
