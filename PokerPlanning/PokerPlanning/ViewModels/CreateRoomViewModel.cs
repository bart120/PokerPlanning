using PokerPlanning.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PokerPlanning.ViewModels
{
    public class CreateRoomViewModel : BaseViewModel
    {
        private ISettingsStore settingsStore;
        private IPokerStore pokerStore;

        public ICommand CreateRoomCommand { get; set; }

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

        public CreateRoomViewModel()
        {
            this.CreateRoomCommand = new Command(executeSaveCommand);
            this.settingsStore = DependencyService.Get<ISettingsStore>(DependencyFetchTarget.GlobalInstance);
            this.pokerStore = DependencyService.Get<IPokerStore>(DependencyFetchTarget.GlobalInstance);

            var load = this.settingsStore.LoadSettings();

            this.RoomName = load?.RoomName ?? "";
            this.Team = load?.Team ?? "";
            this.UserName = load?.UserName ?? "";

        }

        private async void executeSaveCommand(object obj)
        {
            await this.pokerStore.StartRoomAsync(this.roomName);
        }
    }
}
