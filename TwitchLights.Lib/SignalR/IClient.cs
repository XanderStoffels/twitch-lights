using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TwitchLights.Lib.SignalR
{
    public interface IClient
    {
        // Color
        Task ReceiveHex(UserContext user, string hex);

        // Routines
        Task ReceiveUserRoutine(string routine, UserContext context);
        Task ReceiveRoutine(string routine);

        // Status
        Task ReceivePingEvent(string status);
        Task ReceiveErrorEvent(string error);
        Task ReceiveInfoEvent(string info);
        Task ReceiveJoinEvent(int count);
        Task ReceiveLeaveEvent(int count);

    }
}
