using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _106LibrarySystem
{
    public class loanedBooks
    {
        public int bookID { get; set; }
        public int userID { get; set; }
        public DateTime loanDate { get; set; }
        public DateTime dueDate { get; set; }
        public DateTime? returnDate { get; set; }
        public string loanStatus { get; set; }
        public LibraryDatabase.Book Book { get; set; }
    }
}