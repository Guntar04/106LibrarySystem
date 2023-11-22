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
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : UserControl
    {            
        public HomeScreen()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MemberPage memberPage = new MemberPage();
            HomeContent.Content = memberPage;
        }
        private void Image_Click(object sender, MouseButtonEventArgs e)
        {
            MemberBookDetail memberBookDetail = new MemberBookDetail();
            HomeContent.Content = memberBookDetail;
        }
        private void Catalogue_Click(object sender, RoutedEventArgs e)
        {
            MemberBrowsing memberBrowsing = new MemberBrowsing();
            HomeContent.Content = memberBrowsing;
        }
    }
}
