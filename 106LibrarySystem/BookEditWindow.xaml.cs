using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using _106LibrarySystem;
using static LibraryDatabase.BookViewModel;

namespace LibraryDatabase
{
    /// <summary>
    /// Interaction logic for BookEditWindow.xaml
    /// </summary>
    public partial class BookEditWindow : Window
    {

        public BookViewModel BookViewModel { get; set; }

        public BookEditWindow(Book selectedBook, BookViewModel sharedViewModel)
        {
            InitializeComponent();
            BookViewModel = sharedViewModel;
            BookViewModel.CurrentBook = selectedBook;
            DataContext = BookViewModel.CurrentBook;

        }

        private void ChangeImageButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            openFileDialog.DefaultExt = ".png";
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";

            Nullable<bool> result = openFileDialog.ShowDialog();

            // Gets the selected file name and display in a TextBox
            if (result == true)
            {
                // Updates the ImagePath property of the CurrentBook
                BookViewModel.CurrentBook.ImagePath = openFileDialog.FileName;

                // Updates the Image control
                UpdateImage();
            }
        }
        private void UpdateImage()
        {
            // Reloads the image to reflect the changes
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(BookViewModel.CurrentBook.ImagePath);
            bitmap.EndInit();

            // Sets the Image control source
            bookImage.Source = bitmap;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateBindings();
            // Update the book information from the textboxes
            UpdateBookInformation();
            // Closes the window or perform other actions
            Close();
        }
        private void UpdateBindings()
        {
            // Manually update the bindings to apply changes immediately
            BindingExpression be;

            // Update 'name' binding
            be = NameTextBox.GetBindingExpression(TextBox.TextProperty);
            be?.UpdateSource();

            // Update 'author' binding
            be = AuthorTextBox.GetBindingExpression(TextBox.TextProperty);
            be?.UpdateSource();

            be = AvailabilityTextBox.GetBindingExpression(TextBox.TextProperty);
            be?.UpdateSource();
        }

        private void UpdateBookInformation()
        {
            // Save the changes made to the CurrentBook back to the Books collection
            var existingBook = BookViewModel.Books.FirstOrDefault(b => b.Id == BookViewModel.CurrentBook.Id);
            if (existingBook != null)
            {


                existingBook.name = BookViewModel.CurrentBook.name;
                existingBook.author = BookViewModel.CurrentBook.author;
                existingBook.genre = BookViewModel.CurrentBook.genre;
                existingBook.availability = BookViewModel.CurrentBook.availability;
                existingBook.language = BookViewModel.CurrentBook.language;
                existingBook.pageNum = BookViewModel.CurrentBook.pageNum;
                existingBook.date = BookViewModel.CurrentBook.date;
                existingBook.ImagePath = BookViewModel.CurrentBook.ImagePath;
            }

            BookViewModel.UpdateBook(existingBook);
        }

    }
}
