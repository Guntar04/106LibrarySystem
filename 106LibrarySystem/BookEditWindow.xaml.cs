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
using System.Windows.Shapes;

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
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension
            openFileDialog.DefaultExt = ".png";
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openFileDialog.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Update the ImagePath property of the CurrentBook
                BookViewModel.CurrentBook.ImagePath = openFileDialog.FileName;

                // Update the Image control
                UpdateImage();
            }
        }

        private void UpdateImage()
        {
            // Reload the image to reflect the changes
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(BookViewModel.CurrentBook.ImagePath);
            bitmap.EndInit();

            // Set the Image control source
            bookImage.Source = bitmap;
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Update the book information from the textboxes
             UpdateBookInformation();

            UpdateBindings();

            // Close the window or perform other actions
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

            // Update other bindings as needed
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

                
                // Notify the UI about the changes (if needed)
            }
        }

    }
}
