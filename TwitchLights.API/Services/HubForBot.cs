using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitchLights.Lib.SignalR;

namespace TwitchLights.API.Services
{
    public class HubForBot : IHubForBot
    {
        private readonly HubConnection _connection;
        public bool IsConnection => _connection.State == HubConnectionState.Connected;
        public event Action<string, string> OnUserJoin;
        public event Action<string> OnUserLeave;

        public HubForBot()
        {
            string url = @"https://twitchlights.xanderapp.com/twitchpipeline";
#if DEBUG
            url = @"https://localhost:5001/twitchpipeline";
#endif
            _connection = new HubConnectionBuilder()
                .WithUrl(url)
                .WithAutomaticReconnect()
                .Build();

            _connection.On<string,string>("UserJoin", (id, channel) => OnUserJoin?.Invoke(id, channel));
            _connection.On<string>("UserLeave", id => OnUserLeave?.Invoke(id));
        }
        public Task RegisterAsBot()
        {
            return _connection.InvokeAsync("RegisterAsBot");
        }

        public Task SendError(string error)
        {
            return _connection.InvokeAsync("SendError", error);
        }

        public Task SendHex(string channel, UserContext user, string hex)
        {
            return _connection.InvokeAsync("SendHex", channel, user, hex);
        }

        public Task SendInfo(string info)
        {
            return _connection.InvokeAsync("SendInfo", info);
        }

        public Task SendJoin(int count)
        {
            return _connection.InvokeAsync("SendJoin", count);
        }

        public Task SendLeave(int count)
        {
            return _connection.InvokeAsync("SendLeave", count);
        }

        public Task SendPing(string status)
        {
            return _connection.InvokeAsync("SendPing", status);
        }

        public Task StartAsync()
        {
            return _connection.StartAsync();
        }

        public Task StopAsync()
        {
            return _connection.StopAsync();
        }

    }
}
