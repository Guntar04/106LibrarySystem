using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
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
using System.Windows.Controls.Primitives;

namespace _106LibrarySystem
{
    public partial class MemberPage : UserControl
    {
        public User currentUser;
        public List<Book> userBooks = new List<Book>();
        HomeScreen homeScreen = new HomeScreen();
        MemberBrowsing memberBrowsing = new MemberBrowsing();

        public MemberPage()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MemberContent.Content = homeScreen;
        }

        private void Catalogue_Click(object sender, RoutedEventArgs e)
        {
            MemberContent.Content = memberBrowsing;
        }

        private void Log_Out(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            MemberContent.Content = loginPage;
        }

        public void SetCurrentUser(User user)
        {
            currentUser = user;
            UpdateUserDetails();
            
        }

        private void UpdateUserDetails()
        {
            if (currentUser != null)
            {
                tbFirstname.Text = currentUser.FirstName;
                tbJoinDate.Text = currentUser.JoinDate;
                tbPhoneNumber.Text = currentUser.PhoneNumber;
                tbEmailAddress.Text = currentUser.EmailAddress;
                tbID.Text = currentUser.ID.ToString();
            }
        }
        private void GenerateBookImages()
        {
            // Clear existing images
            BookStackPanel.Children.Clear();

            if (userBooks != null)
            {
                foreach (Book book in userBooks)
                {
                    Image bookImage = new Image
                    {
                        Source = new BitmapImage(new Uri(book.ImagePath)), // Replace with actual image path
                        Width = 120,
                        Height = 205,
                        Margin = new Thickness(15)
                    };
                    BookStackPanel.Children.Add(bookImage);
                }
            }
            else
            {
                MessageBox.Show("No user books found.");
            }
        }
        

    }
}

