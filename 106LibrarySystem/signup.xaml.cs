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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : UserControl
    {
        HomeScreen homePage = new HomeScreen();
        MainWindow login = new MainWindow();
        public SignUp()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SignInContent.Content = homePage;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SignInContent.Content = login;
        }
    }
}
