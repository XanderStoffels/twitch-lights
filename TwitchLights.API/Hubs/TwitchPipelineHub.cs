using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitchLib.Client.Models;
using TwitchLights.API.Services;
using TwitchLights.Lib.SignalR;

namespace TwitchLights.API.Hubs
{
    public class TwitchPipelineHub : Hub<IBotClient>, IHubForBot, IHubForClient
    {
        private static string _bot;

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            if (!string.IsNullOrWhiteSpace(_bot))
                await Bot.UserLeave(this.Context.ConnectionId);

            await base.OnDisconnectedAsync(exception);
        }

        // IHubForBot
        public Task RegisterAsBot()
        {
            if (string.IsNullOrWhiteSpace(_bot))
                _bot = this.Context.ConnectionId;
  
            return Task.CompletedTask;
        }
        public Task SendError(string error)
        {
            return this.AllExceptBot.ReceiveErrorEvent(error);
        }
        public Task SendHex(string channel, UserContext user, string hex)
        {
            channel = channel.ToLower();
            return this.Clients.Group(channel).ReceiveHex(user, hex);
        }
        public Task SendInfo(string info)
        {
            return this.AllExceptBot.ReceiveInfoEvent(info);
        }
        public Task SendJoin(int count)
        {
            return this.AllExceptBot.ReceiveJoinEvent(count);
        }
        public Task SendLeave(int count)
        {
            return this.AllExceptBot.ReceiveLeaveEvent(count);
        }
        public Task SendPing(string status)
        {
            return this.AllExceptBot.ReceivePingEvent(status);
        }

        // IHubForClient
        public async Task Subscribe(string channel)
        {
            await EnsureBotInit();
            channel = channel.ToLower();
            await this.Groups.AddToGroupAsync(this.Context.ConnectionId, channel);
            await this.Bot.UserJoin(this.Context.ConnectionId, channel);
        }
        public async Task Unsubscribe(string channel)
        {
            await EnsureBotInit();
            channel = channel.ToLower();
            await this.Groups.RemoveFromGroupAsync(this.Context.ConnectionId, channel);
            await this.Bot.UserLeave(this.Context.ConnectionId);
        }

        // Helper functions.
        private IBotClient Bot => this.Clients.Client(_bot);
        private IBotClient AllExceptBot => this.Clients.AllExcept(new[] { _bot });
        private async ValueTask<bool> EnsureBotInit()
        {
            if (string.IsNullOrEmpty(_bot))
            {
                await this.Clients.Caller.ReceiveErrorEvent("The Twitch Bot is not connected!");
                return false;
            }
            return true;
        }
    }
}
