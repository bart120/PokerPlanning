using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibPockerPlanning;
using Microsoft.AspNetCore.SignalR.Client;

namespace PokerPlanning.Services
{
    public class RoomStore : IRoomStore
    {
        private readonly HubConnection hubRoom;
        private const string URL = "https://signalrpokerplanning.azurewebsites.net/roomhub";

        public event Func<RoomModel, Task> CreateRoomEvent;

        public RoomStore()
        {
            hubRoom = new HubConnectionBuilder()
                .WithUrl(URL)
                .Build();
            connect();
        }

        private async Task connect()
        {
            await hubRoom.StartAsync();
            this.hubRoom.On<RoomModel>("ReceiveNewRoom", async (room) =>
            {
                await this?.CreateRoomEvent(room);
            });
        }

        public async Task CreateRoom(RoomModel room)
        {
            await this.hubRoom.InvokeAsync("CreateRoom", room);
        }

        public async Task JoinRoom(string roomName, string pseudo)
        {
            await this.hubRoom.InvokeAsync("JoinRoom", roomName, pseudo);
        }
    }
}
