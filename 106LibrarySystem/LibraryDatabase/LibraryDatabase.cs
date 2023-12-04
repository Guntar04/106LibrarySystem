using _106LibrarySystem;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LibraryDatabase
{
    public class LibraryDatabase : DbContext
    {
        public DbSet<Loans> Loans { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        private const string ConnectionString = "LibraryDatabase.db";
        
        public void SaveChanges(Loans loan)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO loanedBooks (bookID, userID, loanDate, dueDate, loanStatus) " +
                                     "VALUES (@bookID, @userID, @loanDate, @dueDate, @loanStatus)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@bookID", loan.bookID);
                    command.Parameters.AddWithValue("@userID", loan.userID);
                    command.Parameters.AddWithValue("@loanDate", loan.loanDate);
                    command.Parameters.AddWithValue("@dueDate", loan.dueDate);
                    command.Parameters.AddWithValue("@loanStatus", loan.loanStatus);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public class Book
        {
        }
    }
}
