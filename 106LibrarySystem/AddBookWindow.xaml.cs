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
    public partial class AddBookWindow : Window
    {
        public AddBookWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle save logic here
            // You can access input values like this: TitleTextBox.Text
            Close(); // Close the window
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle cancel logic here
            Close(); // Close the window
        }
    }
}

