using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokerPlanning.Services
{
    public interface IPokerStore
    {
        Task StartRoomAsync(string roomName);

        Task StopRoomAsync(string roomName);

        Task GetRoomListAsync();


    }
}
