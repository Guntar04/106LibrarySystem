using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using Dapper;

namespace LibraryDatabase
{
    public class BookViewModel : INotifyPropertyChanged
    {


        private ObservableCollection<Book> _books = new ObservableCollection<Book>();

        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set
            {
                if (_books != value)
                {
                    _books = value;
                    OnPropertyChanged(nameof(Books));
                }
            }
        }

        public BookViewModel()
        {
            LoadBooks();
            CurrentBook = new Book();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void LoadBooks()
        {
            string databaseFileName = "LibraryDatabase.db";
            string source = $"Data Source={Path.Combine(Directory.GetCurrentDirectory(), databaseFileName)}";

            using (IDbConnection connection = new SQLiteConnection(source))
            {
                connection.Open();
                var books = connection.Query<Book>("SELECT * FROM books", new DynamicParameters()).ToList();

                foreach (var book in books)
                {
                    book.ImagePath = GetImagePathFromDatabase(connection, book.Id);

                    if (book.Id == 0)
                    {
                        // If the Id is not set, retrieve the correct Id from the database
                        book.Id = connection.ExecuteScalar<int>("SELECT last_insert_rowid()");
                    }

                    Books.Add(book);
                }
            }
        }

        private string GetImagePathFromDatabase(IDbConnection connection, int bookId)
        {
            // Example query (replace with your actual database schema and query)
            string query = "SELECT ImagePath FROM books WHERE Id = @BookId";
            return connection.ExecuteScalar<string>(query, new { BookId = bookId }) ?? "";
        }

        public void AddBook(Book newBook)
        {
            // Save the new book to the database
            string databaseFileName = "LibraryDatabase.db";
            string source = $"Data Source={Path.Combine(Directory.GetCurrentDirectory(), databaseFileName)}";

            using (IDbConnection connection = new SQLiteConnection(source))
            {
                connection.Open();

                connection.Execute(
                    "INSERT INTO books (name, author, genre, availability, language, pageNum, date, ImagePath) " +
                    "VALUES (@name, @author, @genre, @availability, @language, @pageNum, @date, @ImagePath)",
                    new
                    {
                        name = newBook.name,
                        author = newBook.author,
                        genre = newBook.genre,
                        availability = newBook.availability,
                        language = newBook.language,
                        pageNum = newBook.pageNum,
                        date = newBook.date,
                        ImagePath = newBook.ImagePath
                    });

                int lastInsertedId = connection.ExecuteScalar<int>("SELECT last_insert_rowid()");

                newBook.Id = lastInsertedId;
                newBook.ImagePath = GetImagePathFromDatabase(connection, lastInsertedId);

                Books.Add(newBook);

            }
        }


        private Book _currentBook;

        public Book CurrentBook
        {
            get { return _currentBook; }
            set
            {
                if (_currentBook != value)
                {
                    _currentBook = value;
                    OnPropertyChanged(nameof(CurrentBook));
                }
            }
        }

        public void RemoveBook(Book book)
        {
            if (book == null)
            {
                // Handle the case where 'book' is null (optional)
                return;
            }

            // Remove the book from the database
            string databaseFileName = "LibraryDatabase.db";
            string source = $"Data Source={Path.Combine(Directory.GetCurrentDirectory(), databaseFileName)}";

            using (IDbConnection connection = new SQLiteConnection(source))
            {
                connection.Open();

                // Add a null check for 'book.Id'
                if (book.Id != 0)
                {
                    connection.Execute("DELETE FROM books WHERE Id = @BookId", new { BookId = book.Id });
                }
                else
                {
                    // Log or handle the case where 'book.Id' is 0
                }
            }

            // Remove the book from the collection
            Books.Remove(book);
        }



    }
}
