using PokerPlanning.Connections;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokerPlanning.Services
{
    public class PokerStore : IPokerStore
    {
        private readonly PokerConnection connection;

        public Task GetRoomListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task StartRoomAsync(string roomName)
        {
            await this.connection.Start();
            await this.connection.CreateRoom(new Models.RoomModel { Name = roomName });

        }

        public Task StopRoomAsync(string roomName)
        {
            throw new NotImplementedException();
        }

        public PokerStore()
        {
            this.connection = new PokerConnection();
          
        }
    }
}
