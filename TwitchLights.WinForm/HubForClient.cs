using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using TwitchLights.Lib.SignalR;

namespace TwitchLights.WinForm
{
    public class HubForClient : IHubForClient
    {
        private readonly HubConnection _connection;

        // Color
        public event Action<UserContext, string> ReceiveHex;

        // Routines
        public event Action<string, UserContext> ReceiveUserRoutine;
        public event Action<string> ReceiveRoutine;

        // Status
        public event Action<string> ReceivePingEvent;
        public event Action<string> ReceiveErrorEvent;
        public event Action<string> ReceiveInfoEvent;
        public event Action<int> ReceiveJoinEvent;
        public event Action<int> ReceiveLeaveEvent;

        public HubForClient()
        {
            string url = @"https://twitchlights.xanderapp.com/twitchpipeline";
#if DEBUG
            url = @"https://localhost:5001/twitchpipeline";
#endif
            _connection = new HubConnectionBuilder()
                .WithUrl(url)
                .WithAutomaticReconnect()
                .Build();

            _connection.On<UserContext, string>("ReceiveHex", (user, h) => ReceiveHex?.Invoke(user,h));
            _connection.On<string, UserContext>("ReceiveUserRoutine", (m, user) => ReceiveUserRoutine?.Invoke(m, user));
            _connection.On<string>("ReceiveRoutine", m => ReceiveRoutine?.Invoke(m));
            _connection.On<string>("ReceivePingEvent", m => ReceivePingEvent?.Invoke(m));
            _connection.On<string>("ReceiveErrorEvent", m => ReceiveErrorEvent?.Invoke(m));
            _connection.On<string>("ReceiveInfoEvent", m => ReceiveInfoEvent?.Invoke(m));
            _connection.On<int>("ReceiveJoinEvent", c => ReceiveJoinEvent?.Invoke(c));
            _connection.On<int>("ReceiveLeaveEvent", c =>  ReceiveLeaveEvent?.Invoke(c));
        }

        public Task Subscribe(string channel)
        {
            return _connection.SendAsync("Subscribe", channel);
        }

        public Task Unsubscribe(string channel)
        {
            return _connection.SendAsync("Unsubscribe", channel);
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
