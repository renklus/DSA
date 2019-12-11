using System;
using System.Collections.Generic;
using System.Text;
using Frontend.Commands;

namespace Frontend.ViewModel
{
    class MenuViewModel : BindableBase
    {
        public RelayCommand GoToCommand { get; set; }

        public MenuViewModel()
        {
            GoToCommand = new RelayCommand(GoTo);
        }

        public void GoTo()
        {
            
        }
    }
}
