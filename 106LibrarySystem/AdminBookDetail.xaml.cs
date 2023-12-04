using LibraryDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _106LibrarySystem
{
    /// <summary>
    /// Interaction logic for AdminBookDetail.xaml
    /// </summary>
    public partial class AdminBookDetail : UserControl
    {
        private Book selectedBook;
        private static User currentUser;
        public AdminBookDetail(Book selectedBook, User currentUser)
        {
            InitializeComponent();
            DisplayBookDetails(selectedBook);
        }

        public AdminBookDetail(Book selectedBook)
        {
            this.selectedBook = selectedBook;
        }

        private void Home_Admin(object sender, RoutedEventArgs e)
        {
            AdminHome adminHome = new AdminHome();
            AdminBookContent.Content = adminHome;
        }
        private void Catalouge_Admin(object sender, RoutedEventArgs e)
        {
            AdminBrowsing adminBrowsing = new AdminBrowsing();
            AdminBookContent.Content = adminBrowsing;
        }
        private void Profile_Admin(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            adminPage.SetCurrentUser(currentUser);
            AdminBookContent.Content = adminPage;
        }

        public void DisplayBookDetails(Book selectedBook)
        {
            if (selectedBook != null)
            {
                BookName.Text = selectedBook.name;
                Author.Text = selectedBook.author;
                Genre.Text = selectedBook.genre;
                Availability.Text = selectedBook.DisplayAvailability;
                Language.Text = selectedBook.language;
                PageNum.Text = selectedBook.pageNum.ToString();
                Date.Text = selectedBook.date.ToString();
                Description.Text = selectedBook.description;

                if (!string.IsNullOrEmpty(selectedBook.ImagePath))
                {
                    // Check if ImagePath is not null or empty before creating Uri
                    BookImage.Source = new BitmapImage(new Uri(selectedBook.ImagePath, UriKind.RelativeOrAbsolute));
                }
            }
            else
            {
                ClearBookDetails();
            }
        }

        private void ClearBookDetails()
        {
            BookName.Text = string.Empty;
            Author.Text = string.Empty;
            Genre.Text = string.Empty;
            Availability.Text = string.Empty;
            Language.Text = string.Empty;
            PageNum.Text = string.Empty;
            Date.Text = string.Empty;
            Description.Text = string.Empty;
            BookImage.Source = null;
        }
        public void SetCurrentUser(User user)
        {
            currentUser = user;
        }
    }
}
