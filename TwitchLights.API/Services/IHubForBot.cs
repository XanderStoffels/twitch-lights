using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitchLights.Lib.SignalR;

namespace TwitchLights.API.Services
{
    interface IHubForBot
    {
        Task RegisterAsBot();
        Task SendPing(string status);
        Task SendError(string error);
        Task SendInfo(string info);
        Task SendJoin(int count);
        Task SendLeave(int count);
        Task SendHex(string channel, UserContext user, string hex);
    }
}
