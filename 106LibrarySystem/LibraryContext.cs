using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace LibraryDatabase
{
    public class LibraryContext
    {
        //private string ConnectionString { get; }

        private ObservableCollection<Loans> _loans = new ObservableCollection<Loans>();
        //public List<Loans> Loans { get; set; } = new List<Loans>();

        public ObservableCollection<Loans> Loans
        {
            get { return _loans; }
            set
            {
                if (_loans != value)
                {
                    _loans = value;
                    OnPropertyChanged(nameof(Loans));
                }
            }
        }

        public LibraryContext()
        {
            
        }

        public IEnumerable<Loans> GetLoans()
        {
            string databaseFileName = "LibraryDatabase.db";
            string source = $"Data Source={Path.Combine(Directory.GetCurrentDirectory(), databaseFileName)}";
            // Implement logic to fetch loans from the database using ADO.NET
            // Example using SqlConnection and SqlCommand:
            using (SqlConnection connection = new SqlConnection(source))
            {
                connection.Open();

                // Example SQL command
                string sql = "SELECT * FROM Loans";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // Execute command and read results
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Parse results and return a collection of Loans
                        List<Loans> loans = new List<Loans>();
                        while (reader.Read())
                        {
                            Loans loan = new Loans
                            {
                                // Populate properties from reader
                                // e.g., loan.loanID = reader.GetInt32(reader.GetOrdinal("loanID"));
                            };
                            loans.Add(loan);
                        }
                        return loans;
                    }
                }
            }
        }

        public void AddLoan(Loans loan)
        {
            string databaseFileName = "LibraryDatabase.db";
            string source = $"Data Source={Path.Combine(Directory.GetCurrentDirectory(), databaseFileName)}";
            // Implement logic to add a loan to the database using ADO.NET
            // Example using SqlConnection and SqlCommand:
            using (SQLiteConnection connect = new SQLiteConnection(source))
            {

                connect.Open();
                var sqlUpdate = connect.CreateCommand();

                sqlUpdate.CommandText = @"INSERT INTO loanedBooks (bookID, userID, loanDate, dueDate, loanStatus) VALUES ($bookID, $userID, $loanDate, $dueDate, $loanStatus)";

                sqlUpdate.Parameters.AddWithValue("$bookID", loan.bookID);
                sqlUpdate.Parameters.AddWithValue("$userID", loan.userID);
                sqlUpdate.Parameters.AddWithValue("$loanDate", loan.loanDate);
                sqlUpdate.Parameters.AddWithValue("$dueDate", loan.dueDate);
                sqlUpdate.Parameters.AddWithValue("$loanStatus", loan.loanStatus);

                sqlUpdate.ExecuteNonQuery();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Add other methods for managing books, users, etc.
    }
}
