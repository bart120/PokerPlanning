using PokerPlanning.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PokerPlanning.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private bool isEnabledMenu;
        private ISettingsStore settingsStore;

        public bool IsEnabledMenu
        {
            get { return isEnabledMenu; }
            set { SetProperty(ref isEnabledMenu, value); }
        }



        public MainViewModel()
        {
            this.settingsStore = DependencyService.Get<ISettingsStore>(DependencyFetchTarget.GlobalInstance);
            var settings = this.settingsStore.LoadSettings();
            IsEnabledMenu = (settings != null);
        }
        
    }
}
