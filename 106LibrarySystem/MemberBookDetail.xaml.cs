using LibraryDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static LibraryDatabase.BookViewModel;

namespace _106LibrarySystem
{
    public partial class MemberBookDetail : UserControl
    {
        private Book selectedBook;
        private User currentUser;
        private LibraryContext context;

        public MemberBookDetail(Book selectedBook, User currentUser)
        {
            InitializeComponent();
            this.selectedBook = selectedBook;
            this.currentUser = currentUser;
            DisplayBookDetails(selectedBook);

            // Subscribe to the BookUpdated event
            bookViewModel.BookUpdated += BookViewModel_BookUpdated;
        }

        private void BookViewModel_BookUpdated(object sender, BookUpdatedEventArgs e)
        {
            // Update displayed book details when the event is triggered
            DisplayBookDetails(e.UpdatedBook);
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            BookDetails.Content = new HomeScreen();
        }

        private void Catalogue_Click(object sender, RoutedEventArgs e)
        {
            BookDetails.Content = new MemberBrowsing();
        }

        private void DisplayBookDetails(Book selectedBook)
        {
            BookImage.Source = new BitmapImage(new Uri(selectedBook.ImagePath, UriKind.RelativeOrAbsolute));
            BookName.Text = selectedBook.name;
            Author.Text = selectedBook.author;
            Genre.Text = selectedBook.genre;
            Availability.Text = selectedBook.DisplayAvailability;
            Language.Text = selectedBook.language;
            PageNum.Text = selectedBook.pageNum.ToString();
            Date.Text = selectedBook.date.ToString();
            Description.Text = selectedBook.description;
        }

        private void Borrow_Click(object sender, RoutedEventArgs e)
        {
            if (currentUser != null && selectedBook != null && context != null)
            {
                int bookID = selectedBook.Id;
                int userID = currentUser.ID;

                DateTime currentDate = DateTime.Now;
                DateTime dueDate = currentDate.AddDays(7);

                var loan = new Loans
                {
                    bookID = bookID,
                    userID = userID,
                    loanDate = currentDate,
                    dueDate = dueDate,
                    loanStatus = "Loaned"
                };

                context.Loans.Add(loan);

                MessageBox.Show("Book borrowed successfully!");
            }
            else
            {
                MessageBox.Show("User or book not selected.");
            }
        }

        private void Pre_Book_Click(object sender, RoutedEventArgs e)
        {
            BorrowOrPreBook("Pre-Booked");
        }

        private void BorrowOrPreBook(string status)
        {
            if (currentUser != null && selectedBook != null)
            {
                int loanID = GetNewLoanID();

                DateTime currentDate = DateTime.Now;
                DateTime dueDate = currentDate.AddDays(7);

                Loans newLoan = new Loans
                {
                    loanID = loanID,
                    bookID = selectedBook.Id,
                    userID = currentUser.ID,
                    loanDate = currentDate,
                    dueDate = dueDate,
                    loanStatus = status
                };

                AddNewLoanToDatabase(newLoan);
                MessageBox.Show($"Book {status.ToLower()} successfully!");
            }
        }

        private void AddNewLoanToDatabase(Loans newLoan)
        {
            context.Loans.Add(newLoan);
        }

        private int GetNewLoanID()
        {
            var existingLoans = context.Loans as IEnumerable<Loans>;

            if (existingLoans != null && existingLoans.Any())
            {
                int maxLoanID = existingLoans.Max(l => l.loanID);
                return maxLoanID + 1;
            }
            else
            {
                return 1;
            }
        }
    }
}
