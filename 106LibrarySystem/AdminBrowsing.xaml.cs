using _106LibrarySystem;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace LibraryDatabase
{
    /// <summary>
    /// Interaction logic for MemberBrowsing.xaml
    /// </summary>
    public partial class AdminBrowsing : UserControl
    {

        public AdminBrowsing()
        {
            InitializeComponent();
            var bookViewModel = new BookViewModel();
            DataContext = bookViewModel;
            AdminBrowse.DataContext = bookViewModel;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            HomeScreen homeScreen = new HomeScreen();
            AdminBrowse.Content = homeScreen;
        }
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            AdminBrowse.Content = adminPage;
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            AddBookWindow addBookWindow = new AddBookWindow((BookViewModel)DataContext);
            addBookWindow.Owner = Window.GetWindow(this); // Set the owner to enable proper interaction
            addBookWindow.ShowDialog(); // Show the window as a modal dialog
        }

        private void EditCatalogueButton_Click(object sender, RoutedEventArgs e)
        {
            EditCatalogueWindow editCatalogueWindow = new EditCatalogueWindow((BookViewModel)DataContext);
            editCatalogueWindow.Owner = Window.GetWindow(this);
            editCatalogueWindow.ShowDialog();
        }

        private void RemoveBook_Click(object sender, RoutedEventArgs e)
        {
            // Show a confirmation dialog
            MessageBoxResult result = MessageBox.Show("Are you sure you want to remove this book?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // If user clicks Yes, remove the book
            if (result == MessageBoxResult.Yes)
            {
                // Get the book associated with the clicked button
                BookViewModel bookViewModel = (BookViewModel)DataContext;
                Book bookToRemove = ((Button)sender).DataContext as Book;

                if (bookToRemove != null)
                {
                    // Remove the book from the database and UI
                    bookViewModel.RemoveBook(bookToRemove);
                }
                else
                {
                    // Log or handle the case where 'bookToRemove' is null
                }


            }

        }

        private void ToggleRemoveButtons_Click(object sender, RoutedEventArgs e)
        {
            BookViewModel bookViewModel = (BookViewModel)DataContext;

            // Toggle the visibility of "Remove Book" buttons
            bookViewModel.IsRemoveButtonVisible = !bookViewModel.IsRemoveButtonVisible;
        }


    }
}
