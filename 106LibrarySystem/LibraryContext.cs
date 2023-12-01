using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace LibraryDatabase
{
    public class LibraryContext
    {
        private string ConnectionString { get; }
        public List<Loans> Loans { get; set; } = new List<Loans>();

        public LibraryContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IEnumerable<Loans> GetLoans()
        {
            // Implement logic to fetch loans from the database using ADO.NET
            // Example using SqlConnection and SqlCommand:
            using (SqlConnection connection = new SqlConnection(ConnectionString))
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
            // Implement logic to add a loan to the database using ADO.NET
            // Example using SqlConnection and SqlCommand:
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Example SQL command
                string sql = "INSERT INTO Loans (bookID, userID, loanDate, dueDate, loanStatus) VALUES (@bookID, @userID, @loanDate, @dueDate, @loanStatus)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@bookID", loan.bookID);
                    command.Parameters.AddWithValue("@userID", loan.userID);
                    command.Parameters.AddWithValue("@loanDate", loan.loanDate);
                    command.Parameters.AddWithValue("@dueDate", loan.dueDate);
                    command.Parameters.AddWithValue("@loanStatus", loan.loanStatus);

                    // Execute command
                    command.ExecuteNonQuery();
                }
            }
        }

        // Add other methods for managing books, users, etc.
    }
}
