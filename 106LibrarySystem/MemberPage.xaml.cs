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
    /// Interaction logic for MemberPage.xaml
    /// </summary>
    public partial class MemberPage : UserControl
    {
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
    }
}
