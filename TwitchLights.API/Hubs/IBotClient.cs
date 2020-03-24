using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitchLights.Lib.SignalR;

namespace TwitchLights.API.Hubs
{
    public interface IBotClient : IClient
    {
        public Task UserJoin(string connectionId, string channel);
        public Task UserLeave(string connectionId);
    }
}
