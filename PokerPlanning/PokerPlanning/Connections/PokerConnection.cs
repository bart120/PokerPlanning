
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using PokerPlanning.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace PokerPlanning.Connections
{
    public class PokerConnection
    {
        private const string URL = "Endpoint=https://pokerplanning2019.service.signalr.net;AccessKey=duPEnl8pu5+nWMBDffFPTSGNpcBYBkB8UoTuouTEgRg=;Version=1.0;";

        private readonly HubConnection connection;

        public Func<RoomModel, Task> NewRoom { get; set; }

        public PokerConnection()
        {
            connection = new HubConnectionBuilder().WithUrl(URL).Build();
        }

        public async Task Start()
        {
            this.connection.Closed += async (error) =>
            {
                await this.connection.StartAsync();
            };

            this.connection.On<RoomModel>("CreateRoom", async (value) =>
            {
                Debug.WriteLine(value);
                await NewRoom(value);
            });

            await this.connection.StartAsync();
        }

        public async Task CreateRoom(RoomModel room)
        {
            //await this.connection.Send(new ActionModel { Action = "CreateRoom", Value = room });
            //await this.connection.SendAsync("CreateRoom", room);
            await this.connection.InvokeAsync<RoomModel>("CreateRoom", room);
        }

    }
}
