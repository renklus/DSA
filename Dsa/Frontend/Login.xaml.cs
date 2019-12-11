using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Frontend.ViewModel;
using Yahtzee;

namespace Frontend
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();

            User user = new User();
            DataContext = new LoginViewModel(user);
        }

        private void UserLogin(object sender, RoutedEventArgs e)
        {
            SettingsStore.PrivateKey = Pk.Text;
            Window game = new Menu();
            game.Show();
        }
    }
}
