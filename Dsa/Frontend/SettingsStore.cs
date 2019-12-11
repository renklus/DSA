using System;
using System.Collections.Generic;
using System.Text;
using Yahtzee;

namespace Frontend
{
    internal static class SettingsStore
    {
        public static YahtzeeManager YahtzeeManager { get; set; }
        public static string GameId { get; set; }
        public static string PrivateKey { get; set; }
    }
}
