using LibPockerPlanning;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRPokerPlanning.Hubs
{
    //1- Créer le hub
    public class RoomHub : Hub
    {
        public async Task CreateRoom (RoomModel room)
        {
            await Clients.All.SendAsync("ReceiveNewRoom", room);
            await Groups.AddToGroupAsync(Context.ConnectionId, room.Name);
        }

        public async Task JoinRoom(string roomName, string pseudo)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            await Clients.Group(roomName).SendAsync("ReceiveJoinRoom", pseudo);
        }

        public async Task KickUserRoom(string roomName, string pseudo)
        {
            await Clients.Group(roomName).SendAsync("ReceiveKickUserRoom", pseudo);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }
    }
}
