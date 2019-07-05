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
        }
    }
}
