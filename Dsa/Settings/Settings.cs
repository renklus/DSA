using System;
using System.IO;

namespace Settings
{
    public static class Settings
    {
        public static string PrivateKey = File.ReadAllText("PrivateKey.txt");
    }
}
