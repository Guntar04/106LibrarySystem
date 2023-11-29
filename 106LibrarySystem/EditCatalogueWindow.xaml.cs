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

        public EditCatalogueWindow(BookViewModel sharedViewModel)
        {
            InitializeComponent();
            DataContext = sharedViewModel;
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
