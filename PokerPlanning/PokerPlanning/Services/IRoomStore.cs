using LibPockerPlanning;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokerPlanning.Services
{
    public interface IRoomStore
    {
        event Func<RoomModel, Task> CreateRoomEvent;

        event Func<string, Task> JoinRoomEvent;

        event Func<string, Task> KickUserRoomEvent;

        Task CreateRoom(RoomModel room);

        Task JoinRoom(string roomName, string pseudo);

        Task KickUserRoom(string roomName, string pseudo);


    }
}
