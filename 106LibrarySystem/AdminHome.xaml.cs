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
using LibraryDatabase;

namespace _106LibrarySystem
{
    /// <summary>
    /// Interaction logic for AdminHome.xaml
    /// </summary>
    public partial class AdminHome : UserControl
    {
        AdminPage adminPage = new AdminPage();
        AdminBookDetail adminBookDetail = new AdminBookDetail();
        public AdminHome()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminHomeContent.Content = adminPage;
        }
        private void Image_Click(object sender, MouseButtonEventArgs e)
        {
            AdminHomeContent.Content = adminBookDetail;
        }
        private void Catalogue_Click(object sender, RoutedEventArgs e)
        {
            AdminBrowsing adminBrowsing = new AdminBrowsing();
            AdminHomeContent.Content = adminBrowsing;
        }
    }
}
