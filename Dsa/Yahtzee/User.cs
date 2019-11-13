using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace Yahtzee
{
    class User
    {
        public string Name { get; set; }

        public string Wallet { get; set; }

        private SecureString PrivateKey { get; set; }
    }
}
