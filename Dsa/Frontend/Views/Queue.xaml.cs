﻿using System;
using System.Collections.Generic;
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
using Yahtzee;

namespace Frontend.Views
{
    /// <summary>
    /// Interaction logic for Queue.xaml
    /// </summary>
    public partial class Queue : Page
    {
        public Queue()
        {
            InitializeComponent();
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            SettingsStore.YahtzeeManager = new YahtzeeManager(SettingsStore.PrivateKey);
            var gameId = await SettingsStore.YahtzeeManager.StartGameAsync(PartnerAddress.Text);
            SettingsStore.GameId = gameId;
            Window game = new GamePage();
            game.Show();
        }

        private async void Button_Click2(object sender, RoutedEventArgs e)
        {
            SettingsStore.YahtzeeManager = new YahtzeeManager(SettingsStore.PrivateKey);
            //todo Adresse nicht fix
            await SettingsStore.YahtzeeManager.JoinGameAsync(GameId.Text);
            Window game = new GamePage();
            game.Show();
        }
    }
}
