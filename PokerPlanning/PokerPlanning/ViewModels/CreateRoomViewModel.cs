using LibPockerPlanning;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using PokerPlanning.Models;
using PokerPlanning.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PokerPlanning.ViewModels
{
    public class CreateRoomViewModel : BaseViewModel
    {
        
        private ISettingsStore settingsStore;
        private IRoomStore roomStore;


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
            this.CreateRoomCommand = new Command(executeCreateCommand);
            this.settingsStore = DependencyService.Get<ISettingsStore>(DependencyFetchTarget.GlobalInstance);
            this.roomStore = DependencyService.Get<IRoomStore>(DependencyFetchTarget.GlobalInstance);

            var load = this.settingsStore.LoadSettings();

            this.RoomName = load?.RoomName ?? "";
            this.Team = load?.Team ?? "";
            this.UserName = load?.UserName ?? "";


            /*if (Device.RuntimePlatform == Device.UWP)
                url = "http://localhost:52125/roomhub";

            hubRoom = new HubConnectionBuilder()
                .WithUrl(url)
                .Build();

            this.connect();*/
        }


        /*private async Task connect()
        {
            await hubRoom.StartAsync();
            this.hubRoom.On<RoomModel>("ReceiveNewRoom", (room) =>
            {
                Console.WriteLine(room.Name);
            });
        }*/

        private async void executeCreateCommand(object obj)
        {
            await this.roomStore.CreateRoom(new RoomModel
            {
                Locked = false,
                Name = this.RoomName,
                Team = this.Team
            });
            /*await this.hubRoom.InvokeAsync("CreateRoom", new RoomModel
            {
                Locked = false,
                Name = this.RoomName,
                Team = this.Team
            });*/

            //await this.pokerStore.StartRoomAsync(this.roomName);
        }
    }
}
