using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;
using TwitchLights.API.Hubs;
using TwitchLights.Lib.SignalR;

namespace TwitchLights.API.Services
{
    public class TwitchBotBackgroundService : IHostedService
    {
        private readonly string ACCESS_TOKEN;
        private readonly string REFRESH_TOKEN;
        private readonly ConcurrentDictionary<string, HashSet<string>> _watchedChannels;
        private readonly ILogger<TwitchBotBackgroundService> _logger;
        private bool _isHealthy;

        private TwitchClient _twitch;
        private HubForBot _hub;
        public TwitchBotBackgroundService(IConfiguration config, ILogger<TwitchBotBackgroundService> logger)
        {
            this._logger = logger;
            this.ACCESS_TOKEN = config["TwitchAccessToken"];
            this.REFRESH_TOKEN = config["TwitchRefreshToken"];
            if (string.IsNullOrWhiteSpace(this.ACCESS_TOKEN) || string.IsNullOrWhiteSpace(this.REFRESH_TOKEN))
            {
                this._logger.LogError("No ACCESS or REFRESH token found. Bot can not start.");
                return;
            }
            _hub = new HubForBot();
            _hub.OnUserJoin += this.OnUserJoin;
            _hub.OnUserLeave += this.OnUserLeave;
       
            this._watchedChannels = new ConcurrentDictionary<string, HashSet<string>>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _ = PostHealth();

            // Needs to happen at a later time because the SignalR hub needs to be started first.
            _ = Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(3));

                await _hub.StartAsync();
                _logger.LogInformation("Connected to SignalR");

                await _hub.RegisterAsBot();
                _logger.LogInformation("Subscribed to Bot Group");
                _twitch.Connect();
            });

            // Init Twitch bot.
            var credentials = new ConnectionCredentials("proto4bot", ACCESS_TOKEN);
            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30)
            };
            var customClient = new WebSocketClient(clientOptions);
            _twitch = new TwitchClient(customClient);
            _twitch.AddChatCommandIdentifier('!');
            _twitch.Initialize(credentials);
            _twitch.OnJoinedChannel += Twitch_OnJoinedChannel;
            _twitch.OnLeftChannel += Twitch_OnLeftChannel;
            _twitch.OnChatCommandReceived += Twitch_OnChatCommandReceived;
            _twitch.OnConnected += Twitch_OnConnected;

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _twitch.Disconnect();
            return _hub.StopAsync();
        }

        // Twitch events.
        private void Twitch_OnLeftChannel(object sender, OnLeftChannelArgs e)
        {
            // Leaving the channel does not happen here.
            // This happens in the RemoveViewer method.
            _logger.LogInformation($"Left Twitch Channel {e.Channel}");
        }
        private void Twitch_OnConnected(object sender, OnConnectedArgs e)
        {
            _logger.LogInformation("Bot connected to Twitch.");
        }
        private async void Twitch_OnChatCommandReceived(object sender, OnChatCommandReceivedArgs e)
        {
            var triggers = new string[] { "lights", "hue" };
            if (triggers.Contains(e.Command.CommandText) && e.Command.ArgumentsAsList.Count == 1)
            {
                var input = e.Command.ArgumentsAsList[0];
                var hex = HexFinder.Lookup(input);
                if (hex != null)
                    input = hex;
               
                await _hub.SendHex(e.Command.ChatMessage.Channel, new UserContext {
                    Id = e.Command.ChatMessage.UserId,
                    IsSub = e.Command.ChatMessage.IsSubscriber,
                    Username = e.Command.ChatMessage.Username
                }, input); 
            }
        }
        private void Twitch_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            _twitch.SendMessage(e.Channel, "Hi chat! I'm watching for light commands now!");
            _logger.LogInformation($"Connected to Twitch Channel {e.Channel}");
        }

        // SignalR events.
        private async void OnUserJoin(string connectionId, string channel)
        {
            if (this._watchedChannels.TryGetValue(channel, out var viewers))
            {
                if (viewers.Contains(connectionId)) return;
                viewers.Add(connectionId);
            }
            else
            {
                this._watchedChannels.TryAdd(channel, new HashSet<string>() { connectionId });
                _twitch.JoinChannel(channel);
                _logger.LogInformation($"Joining channel {channel}.");
            }
            await _hub.SendJoin(this._watchedChannels[channel].Count);
        }
        private void OnUserLeave(string connectionId)
        {
            // Leave a channel if the only watching user leaves.
            foreach (var kv in _watchedChannels)
                if (kv.Value.Contains(connectionId))
                {
                    kv.Value.Remove(connectionId);
                    if (kv.Value.Count == 0)
                    {
                        _twitch.SendMessage(kv.Key, "Leaving channel, bye chat!");
                        _watchedChannels.TryRemove(kv.Key, out var _);
                        _logger.LogInformation($"Leaving channel {kv.Key}.");
                        _twitch.LeaveChannel(kv.Key);

                    }
                    _hub.SendLeave(kv.Value.Count);
                }
        }

        // Health
        private async Task PostHealth(CancellationToken token = default)
        {
            while (!token.IsCancellationRequested)
            {
                if (_hub.IsConnection && _twitch.IsConnected)
                    await _hub.SendPing("PING");
                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        }

    }
}
