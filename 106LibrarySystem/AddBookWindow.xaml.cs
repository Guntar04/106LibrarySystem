using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
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
using Dapper;

namespace LibraryDatabase
{
    public partial class AddBookWindow : Window
    {
        private BookViewModel _bookViewModel;
        public AddBookWindow(BookViewModel bookViewModel)
        {
            InitializeComponent();
            _bookViewModel = bookViewModel;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string title = ItemBox.Text;
            string Author = ItemBox2.Text;
            string Genre = ItemBox3.Text;
            string Availability = ItemBox4.Text;
            string Language = ItemBox5.Text;
            string PageNum = ItemBox6.Text;
            string Date = ItemBox7.Text;
            string databaseFileName = "LibraryDatabase.db";
            string source = $"Data Source={System.IO.Path.Combine(Directory.GetCurrentDirectory(), databaseFileName)}";

            var newBook = new Book
            {
                name = title,
                author = Author,
                genre = Genre,
                language = Language,
                // You may want to set other properties like ImagePath
            };

            int availability;
            if (int.TryParse(Availability, out availability))
            {
                newBook.availability = availability;
            }
            else
            {
                MessageBox.Show("Invalid availability format. Please enter a valid integer.");
                return; // Exit the method if parsing fails
            }

            int pageNum;
            if (int.TryParse(PageNum, out pageNum))
            {
                newBook.pageNum = pageNum;
            }
            else
            {
                MessageBox.Show("Invalid page number format. Please enter a valid integer.");
                return; // Exit the method if parsing fails
            }

            int date;
            if (int.TryParse(Date, out date))
            {
                newBook.date = date;
            }
            else
            {
                MessageBox.Show("Invalid date format. Please enter a valid integer.");
                return; // Exit the method if parsing fails
            }

            // Set other properties
            newBook.ImagePath = _bookViewModel.CurrentBook.ImagePath;

            _bookViewModel.AddBook(newBook);


            MessageBox.Show("Successfully added a book!");

            // Close the window
            Close();
        }

        private void ItemBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Book Title")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }

        private void ItemBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "Book Title";
                textBox.Foreground = Brushes.Gray;
            }
        }

        private void ItemBox2_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Author")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }

        private void ItemBox2_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "Author";
                textBox.Foreground = Brushes.Gray;
            }
        }

        private void ItemBox3_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Genre")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }

        private void ItemBox3_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "Genre";
                textBox.Foreground = Brushes.Gray;
            }
        }

        private void ItemBox4_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Availability")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }

        private void ItemBox4_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "Availability";
                textBox.Foreground = Brushes.Gray;
            }
        }

        private void ItemBox5_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Language")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }

        private void ItemBox5_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "Language";
                textBox.Foreground = Brushes.Gray;
            }
        }

        private void ItemBox6_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Page Number")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }

        private void ItemBox6_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "Page Number";
                textBox.Foreground = Brushes.Gray;
            }
        }

        private void ItemBox7_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Date")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }

        private void ItemBox7_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "Date";
                textBox.Foreground = Brushes.Gray;
            }
        }

        private void UploadImageButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg;*.gif)|*.png;*.jpeg;*.jpg;*.gif|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                // Get the selected file path
                string imagePath = openFileDialog.FileName;

                // Display the selected image in the UI
                BookImage.Source = new BitmapImage(new Uri(imagePath));

                // Save the image path to the Book object
                _bookViewModel.CurrentBook.ImagePath = imagePath;
            }
        }

    }
}

