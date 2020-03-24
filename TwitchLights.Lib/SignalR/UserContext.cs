using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLights.Lib.SignalR
{
    public class UserContext
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public bool IsSub { get; set; }
    }
}
