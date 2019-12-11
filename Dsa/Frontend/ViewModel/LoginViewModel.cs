using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using Frontend.Commands;
using Yahtzee;

namespace Frontend.ViewModel
{
    public class LoginViewModel : BindableBase
    {
        public RelayCommand UserLogin { get; set; }

        public User User { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _wallet;
        public string Wallet
        {
            get { return _wallet; }
            set { SetProperty(ref _wallet, value); }
        }

        private SecureString _privatekey;
        public SecureString PrivateKey
        {
            get { return _privatekey; }
            set { SetProperty(ref _privatekey, value); }
        }

        public Action<User> OnSave { get; set; }

        public LoginViewModel(User user)
        {
            UserLogin = new RelayCommand(Save);
        }

        public void Save()
        {
            User.Name = Name;
            User.Wallet = Wallet;
            User.PrivateKey = PrivateKey.ToString();

            OnSave?.Invoke(User);
        }
    }
}
