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

namespace _106LibrarySystem
{
    /// <summary>
    /// Interaction logic for AdminBrowsing.xaml
    /// </summary>
    public partial class AdminBrowsing : UserControl
    {
        public AdminBrowsing()
        {
            InitializeComponent();
        }
        private void Profile_Admin(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            AdminBrowsingContent.Content = adminPage;
        }
        private void Home_Admin(object sender, RoutedEventArgs e)
        {
            AdminHome adminHome = new AdminHome();
            AdminBrowsingContent.Content = adminHome;
        }
    }
}
