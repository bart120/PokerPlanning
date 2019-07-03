using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PokerPlanning.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {


        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }


        private string userName;

        public string UserName
        {
            get { return userName; }
            set {
                SetProperty(ref userName, value);
            }
        }

        private string team;

        public string Team
        {
            get { return team; }
            set { SetProperty(ref team, value); }
        }

    }
}
