using LibraryDatabase;
using System;
using System.Collections.Generic; // Add this using directive for List
using System.Windows.Controls;

// Change the access modifier to public
public class Loans
{
    public DateTime? returnDate;

    public int loanID { get; set; }
    public int bookID { get; set; }
    public int userID { get; set; }
    public DateTime loanDate { get; set; }
    public DateTime dueDate { get; set; }
    public string loanStatus { get; set; }
    public Book Book { get; internal set; }
}

public partial class MemberPage : UserControl
{
    public List<Loans> userBooks { get; set; }

    // Rest of your code
}
