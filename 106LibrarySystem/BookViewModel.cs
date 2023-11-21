using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace LibraryDatabase
{
    public class BookViewModel
    {
        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();

        public BookViewModel() {

            LoadBooks();
        }

        private void LoadBooks()
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
                    Books.Add(book);
                }
            }
        }

        private string GetImagePathFromDatabase(IDbConnection connection, int bookId)
        { 

            // Example query (replace with your actual database schema and query)
            string query = "SELECT ImagePath FROM books WHERE Id = @BookId";
            return connection.ExecuteScalar<string>(query, new { BookId = bookId }) ?? ""; // Replace with the actual implementation
        }
    }
}
