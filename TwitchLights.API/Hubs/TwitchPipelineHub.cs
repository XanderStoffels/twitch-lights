using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitchLib.Client.Models;
using TwitchLights.API.Services;

namespace TwitchLights.API.Hubs
{
    public class TwitchPipelineHub : Hub
    {


        public TwitchPipelineHub()
        {
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await this.Clients.Group("Bot").SendAsync("RemoveViewer", this.Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task Subscribe(string channelName)
        {
            channelName = channelName.ToLower();
            await this.Groups.AddToGroupAsync(this.Context.ConnectionId, channelName);
            await this.Clients.Group("Bot").SendAsync("WatchChannel", channelName, this.Context.ConnectionId);
        }

        public async Task BotSubscribe()
        {
            await this.Groups.AddToGroupAsync(this.Context.ConnectionId, "Bot");
        }

        public Task SendHex(string channel, string sender, bool isSub, string hex)
        {
            return this.Clients.Group(channel.ToLower())
                .SendAsync("ReceiveHex", sender, isSub, hex);
        }
    }
}
