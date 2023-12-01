using LibraryDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
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
using static LibraryDatabase.BookViewModel;

namespace _106LibrarySystem
{
    public partial class MemberBookDetail : UserControl
    {
        public MemberBookDetail(Book selectedBook, BookViewModel bookViewModel)
        {
            InitializeComponent();
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
            HomeScreen homeScreen = new HomeScreen();
            BookDetails.Content = homeScreen;
        }
        private void Catalogue_Click(object sender, RoutedEventArgs e)
        {
            MemberBrowsing memberBrowsing = new MemberBrowsing();
            BookDetails.Content = memberBrowsing;
        }

        private void DisplayBookDetails(Book selectedBook)
        {
            BookName.Text = selectedBook.name;
            Author.Text = selectedBook.author;
            Genre.Text = selectedBook.genre;
            Availability.Text = selectedBook.DisplayAvailability;
            Language.Text = selectedBook.language;
            PageNum.Text = selectedBook.pageNum.ToString();
            Date.Text = selectedBook.date.ToString();
            Description.Text = selectedBook.description;
            BookImage.Source = new BitmapImage(new Uri(selectedBook.ImagePath, UriKind.RelativeOrAbsolute));
        }
    }
}
