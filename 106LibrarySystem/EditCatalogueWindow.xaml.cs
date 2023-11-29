using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using LibraryDatabase;

namespace LibraryDatabase
{
    /// <summary>
    /// Interaction logic for EditCatalogueWindow.xaml
    /// </summary>
    public partial class EditCatalogueWindow : Window
    {

        private BookViewModel _viewModel;
        public EditCatalogueWindow(BookViewModel sharedViewModel)
        {
            InitializeComponent();
            DataContext = sharedViewModel;
            _viewModel = new BookViewModel();
            DataContext = _viewModel;
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ApplySearch();
            }
        }

        private void SearchButton_Click(object sender, MouseButtonEventArgs e)
        {
            ApplySearch();
        }

        private void ApplySearch()
        {
            string searchText = searchTextBox.Text.ToLower();
            _viewModel.ApplySearch(searchText);
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (searchTextBox.Text == "Search Library...")
            {
                searchTextBox.Text = "";
            }
        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                searchTextBox.Text = "Search Library...";
            }
        }

private void BookButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var book = (Book)button.DataContext;

            // Pass the shared BookViewModel instance to BookEditWindow
            var bookEditWindow = new BookEditWindow(book, (BookViewModel)DataContext);
            bookEditWindow.ShowDialog();

            // Update MemberBrowsing with changes
            ((BookViewModel)DataContext).UpdateBooks();
        }
    }
}
