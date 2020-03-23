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

namespace TwitchLights.API.Services
{
    public class TwitchBotBackgroundService : IHostedService
    {
        private readonly string ACCESS_TOKEN;
        private readonly string REFRESH_TOKEN;
        private readonly ConcurrentDictionary<string, HashSet<string>> _watchedChannels;
        private readonly ILogger<TwitchBotBackgroundService> _logger;

        private TwitchClient _client;
        private HubConnection _connection;
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
               
            string url = @"https://twitchlights.xanderapp.com/twitchpipeline";
#if DEBUG
            url = @"https://localhost:5001/twitchpipeline";
#endif
            _connection = new HubConnectionBuilder()
                .WithUrl(url)
                .WithAutomaticReconnect()
                .Build();

            _connection.On<string, string>("WatchChannel", WatchChannel);
            _connection.On<string>("RemoveViewer", RemoveViewer);
            this._watchedChannels = new ConcurrentDictionary<string, HashSet<string>>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            if (_connection == null) return Task.CompletedTask;

            // Needs to happen at a later time because the SignalR hub needs to be started first.
            _ = Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(3));

                await _connection.StartAsync();
                _logger.LogInformation("Connected to SignalR");

                await _connection.SendAsync("BotSubscribe");
                _logger.LogInformation("Subscribed to Bot Group");
                _client.Connect();
            });

            var credentials = new ConnectionCredentials("proto4bot", ACCESS_TOKEN);
            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30)
            };
            var customClient = new WebSocketClient(clientOptions);
            _client = new TwitchClient(customClient);
            _client.AddChatCommandIdentifier('!');
            _client.Initialize(credentials);
            _client.OnJoinedChannel += twitch_OnJoinedChannel;
            _client.OnLeftChannel += _client_OnLeftChannel;
            _client.OnChatCommandReceived += _client_OnChatCommandReceived;
            _client.OnConnected += _client_OnConnected;

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _client.Disconnect();
            _client.Disconnect();
            return Task.CompletedTask;
        }

        private void _client_OnLeftChannel(object sender, OnLeftChannelArgs e)
        {
            // Leaving the channel does not happen here.
            // This happens in the RemoveViewer method.
            _logger.LogInformation($"Connected to Twitch Channel {e.Channel}");
        }

        private void _client_OnConnected(object sender, OnConnectedArgs e)
        {
            _logger.LogInformation("Bot connected to Twitch.");
        }

        private async void _client_OnChatCommandReceived(object sender, OnChatCommandReceivedArgs e)
        {
            var triggers = new string[] { "lights", "tl", "l", "hue" };
            if (triggers.Contains(e.Command.CommandText) && e.Command.ArgumentsAsList.Count == 1)
            {
                var input = e.Command.ArgumentsAsList[0];
                var hex = HexFinder.Lookup(input);
                if (hex != null)
                    input = hex;
               
                await _connection.SendAsync("SendHex", e.Command.ChatMessage.Channel, e.Command.ChatMessage.Username,e.Command.ChatMessage.IsSubscriber, input); 
            }
        }

        private void twitch_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            _client.SendMessage(e.Channel, "Hi chat! You can now influence the streamer's or some viewer's lights!");
            _logger.LogInformation($"Connected to Twitch Channel {e.Channel}");

        }

        private void WatchChannel(string channel, string connectionId)
        {
            if (this._watchedChannels.TryGetValue(channel, out var viewers))
            {
                if (viewers.Contains(connectionId)) return;
                viewers.Add(connectionId);
                _client.SendMessage(channel, $"There are currently {viewers.Count} lights reacting to chat!");
            }
            else
            {
                this._watchedChannels.TryAdd(channel, new HashSet<string>() { connectionId });
                _client.JoinChannel(channel);

            }
        }

        private void RemoveViewer(string connectionId)
        {
            // Leave a channel if the only watching user leaves.
            foreach (var kv in _watchedChannels)
                if (kv.Value.Contains(connectionId))
                {
                    kv.Value.Remove(connectionId);
                    _client.SendMessage(kv.Key, $"There are currently {kv.Value.Count} lights reacting to chat!");
                    if (kv.Value.Count == 0)
                    {
                        _client.SendMessage(kv.Key, "Leaving channel, bye chat!");
                        _watchedChannels.TryRemove(kv.Key, out var _);
                        _client.LeaveChannel(kv.Key);

                    }
                }
        }

    }
}
