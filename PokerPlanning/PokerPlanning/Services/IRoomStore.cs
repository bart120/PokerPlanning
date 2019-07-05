﻿using LibPockerPlanning;
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

        Task CreateRoom(RoomModel room);

        Task JoinRoom(string roomName, string pseudo);


    }
}
