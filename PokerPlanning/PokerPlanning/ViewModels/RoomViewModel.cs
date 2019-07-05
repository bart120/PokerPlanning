using PokerPlanning.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace PokerPlanning.ViewModels
{
    public class RoomViewModel : BaseViewModel
    {
        private IRoomStore roomStore;

        public ObservableCollection<string> Users { get; set; }

        private ISettingsStore settingsStore;
        private string roomName;

        public string RoomName
        {
            get { return roomName; }
            set { SetProperty(ref roomName, value); }
        }


        public RoomViewModel(string roomName)
        {
            this.RoomName = roomName;
            this.Users = new ObservableCollection<string>();
            this.settingsStore = DependencyService.Get<ISettingsStore>(DependencyFetchTarget.GlobalInstance);
            this.roomStore = DependencyService.Get<IRoomStore>(DependencyFetchTarget.GlobalInstance);
            this.roomStore.JoinRoomEvent += RoomStore_JoinRoomEvent;
            this.roomStore.JoinRoom(roomName, settingsStore.LoadSettings().UserName);
        }

        private async System.Threading.Tasks.Task RoomStore_JoinRoomEvent(string arg)
        {
            this.Users.Add(arg);
        }
    }
}
