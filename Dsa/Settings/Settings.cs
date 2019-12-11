using System;
using System.IO;

namespace Settings
{
    public static class Settings
    {
        public static string Web3Url = File.ReadAllText("Web3Url.txt");
    }
}
