using PokerPlanning.Models;
using PokerPlanning.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace PokerPlanning.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private ISettingsStore settingsStore;
        public ICommand SaveCommand { get; set; }

        private string roomName;
        public string RoomName
        {
            get { return roomName; }
            set { SetProperty(ref roomName, value); }
        }


        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                SetProperty(ref userName, value);
            }
        }

        private string team;
        public string Team
        {
            get { return team; }
            set { SetProperty(ref team, value); }
        }

        public SettingsViewModel()
        {
            this.SaveCommand = new Command(executeSaveCommand);
            this.settingsStore = DependencyService.Get<ISettingsStore>(DependencyFetchTarget.GlobalInstance);
            var load = this.settingsStore.LoadSettings();

            this.RoomName = load?.RoomName ?? "";
            this.Team = load?.Team ?? "";
            this.UserName = load?.UserName ?? "";

        }

        private void executeSaveCommand(object obj)
        {
            settingsStore.SaveSettings(new SettingsModel { UserName = UserName, RoomName = RoomName, Team = Team });
        }

    }
}
