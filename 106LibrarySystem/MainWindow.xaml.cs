using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
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
using LibraryDatabase;

namespace _106LibrarySystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MemberBookDetail MemberBookDetailInstance { get; private set; }
        public AdminBookDetail AdminBookDetailInstance { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            Book selectedBook = GetSelectedBook();
            AdminBookDetailInstance = new AdminBookDetail(selectedBook);
        }

        private Book GetSelectedBook()
        {
            // Implement a method to obtain or create the selected book
            // For example, you might retrieve it from a list of books, a database, etc.
            // Replace this with your actual logic to get the selected book.
            return new Book(); // Replace with your logic to obtain the selected book
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginCover.Content = loginPage;
        }
    }
}
