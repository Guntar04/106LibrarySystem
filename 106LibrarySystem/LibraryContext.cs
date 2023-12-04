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
    }
}
