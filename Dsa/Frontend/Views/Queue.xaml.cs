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
            //todo Adresse nicht fix
            await new YahtzeeManager(Settings.Settings.PrivateKey).StartGameAsync("0x08c31473a219f22922f47f001611d8bac62fbb6d");
        }

        private async void Button_Click2(object sender, RoutedEventArgs e)
        {
            //todo Adresse nicht fix
            await new YahtzeeManager(Settings.Settings.PrivateKey).JoinGameAsync(_gameid.Text);
        }
    }
}
