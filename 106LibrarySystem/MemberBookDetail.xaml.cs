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
        private static User currentUser;
        private LibraryContext context;

        public MemberBookDetail(Book selectedBook, User currentUser)
        {
            InitializeComponent();
            this.selectedBook = selectedBook;
            DisplayBookDetails(selectedBook);

        }

            private void Home_Click(object sender, RoutedEventArgs e)
        {
            BookDetails.Content = new HomeScreen();
        }

        private void Catalogue_Click(object sender, RoutedEventArgs e)
        {
            BookDetails.Content = new MemberBrowsing();
        }

        public void DisplayBookDetails(Book selectedBook)
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
            var context = new LibraryContext();
            if (currentUser != null && selectedBook != null && context != null)
            {
                int bookID = selectedBook.Id;
                int userID = currentUser.ID;

                if (selectedBook.availability <= 0)
                {
                    MessageBox.Show("Book not in stock!");
                }
                else
                {
                    DateTime currentDate = DateTime.Today;
                    DateTime dueDate = currentDate.AddDays(7);

                    var loan = new Loans
                    {
                        bookID = bookID,
                        userID = userID,
                        loanDate = currentDate,
                        dueDate = dueDate,
                        loanStatus = "Loaned"
                    };

                    context.AddLoan(loan);

                    MessageBox.Show("Book borrowed successfully!");
                }  
            }
            else
            {
                MessageBox.Show("User or book not selected.");
            }
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            MemberPage memberPage = new MemberPage();
            memberPage.SetCurrentUser(currentUser);
            BookDetails.Content = memberPage;
        }
        public void SetCurrentUser(User user)
        {
            currentUser = user;
        }
    }
}
