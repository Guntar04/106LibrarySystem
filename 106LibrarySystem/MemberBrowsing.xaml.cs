using _106LibrarySystem;
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

namespace LibraryDatabase
{
    /// <summary>
    /// Interaction logic for MemberBrowsing.xaml
    /// </summary>
    public partial class MemberBrowsing : UserControl
    {

        public MemberBrowsing()
        {
            InitializeComponent();
            var bookViewModel = new BookViewModel();
            DataContext = bookViewModel;
            MemberBrowse.DataContext = bookViewModel;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            HomeScreen homeScreen = new HomeScreen();
            MemberBrowse.Content = homeScreen;
        }
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            MemberPage memberPage = new MemberPage();
            MemberBrowse.Content = memberPage;
        }

    }
}
