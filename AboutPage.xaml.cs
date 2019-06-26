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
using _2K48.Classы;

namespace _2K48
{
    /// <summary>
    /// Логика взаимодействия для AboutPage.xaml
    /// </summary>
    public partial class AboutPage : Page
    {
        public AboutPage()
        {
            InitializeComponent();
            Initialize();
        }

        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("MainMenuPage.xaml", UriKind.RelativeOrAbsolute));
        }

        public void Initialize()
        {
            Classы.Path Str = new Classы.Path();
            Str.GetPath(-3);
            string path = Str.Str;
            var uriImageSource = new Uri(path, UriKind.RelativeOrAbsolute);
            BitmapImage Image = new BitmapImage(uriImageSource);
            MainMenu.Source = Image;
        }
    }
}
