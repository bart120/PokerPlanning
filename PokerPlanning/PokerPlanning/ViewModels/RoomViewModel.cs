using PokerPlanning.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PokerPlanning.ViewModels
{
    public class RoomViewModel : BaseViewModel
    {
        private IRoomStore roomStore;
        private INavigation nav;

        public ICommand KickUserCommand { get; set; }

        public ObservableCollection<string> Users { get; set; }

        private ISettingsStore settingsStore;
        private string roomName;

        public string RoomName
        {
            get { return roomName; }
            set { SetProperty(ref roomName, value); }
        }


        public RoomViewModel(string roomName, INavigation nav)
        {
            this.RoomName = roomName;
            this.nav = nav;
            this.Users = new ObservableCollection<string>();
            this.KickUserCommand = new Command<string>(executeKickUserCommand);
            this.settingsStore = DependencyService.Get<ISettingsStore>(DependencyFetchTarget.GlobalInstance);
            this.roomStore = DependencyService.Get<IRoomStore>(DependencyFetchTarget.GlobalInstance);
            this.roomStore.JoinRoomEvent += RoomStore_JoinRoomEvent;
            this.roomStore.KickUserRoomEvent += RoomStore_KickUserRoomEvent;
            this.roomStore.JoinRoom(roomName, settingsStore.LoadSettings().UserName);
        }

        private async System.Threading.Tasks.Task RoomStore_KickUserRoomEvent(string arg)
        {
            this.Users.Remove(arg);
            if(this.settingsStore.LoadSettings().UserName == arg)
            {
                await nav.PopModalAsync();
            }
        }

        private async void executeKickUserCommand(string pseudo)
        {
            await this.roomStore.KickUserRoom(this.roomName, pseudo);
        }

        private async System.Threading.Tasks.Task RoomStore_JoinRoomEvent(string arg)
        {
            this.Users.Add(arg);
            await TextToSpeech.SpeakAsync($"{arg} a rejoint le salon.");
        }
    }
}
