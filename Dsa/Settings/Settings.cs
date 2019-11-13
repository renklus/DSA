using System;
using System.IO;

namespace Settings
{
    public static class Settings
    {
        public static string PrivateKey = File.ReadAllText("PrivateKey.txt");
        public static string PrivateAddress = File.ReadAllText("PrivateAddress.txt");
        public static string Web3Url = File.ReadAllText("Web3Url.txt");

    }
}
