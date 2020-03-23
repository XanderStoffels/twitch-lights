using Microsoft.AspNetCore.SignalR.Client;
using Q42.HueApi;
using Q42.HueApi.ColorConverters;
using Q42.HueApi.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwitchLights.WinForm.Properties;

namespace TwitchLights.WinForm
{
    public partial class FrmMain : Form
    {
        private readonly List<string> _lights;
        private readonly HubConnection _connection;
        private readonly ILocalHueClient _hue;
        private readonly Commands _commands;
        private string _channelName;

        public FrmMain(ILocalHueClient hueClient, List<string> lightIds)
        {
            InitializeComponent();
            this._lights = lightIds;
            this._hue = hueClient;

            this._connection = new HubConnectionBuilder()
                .WithAutomaticReconnect()
#if DEBUG
             .WithUrl("https://localhost:5001/twitchpipeline")
#else
             .WithUrl("https://twitchlights.xanderapp.com/twitchpipeline")
#endif
             .Build();

            _connection.On<string, bool, string>("ReceiveHex", HandleHex);
            _commands = new Commands(_hue, lightIds);
        }

        private async void FrmMain_Shown(object sender, EventArgs e)
        {
            ptbStatus.Image = Resources.ReisdentSleeper;

            try
            {
                await _connection.StartAsync();
                await _connection.SendAsync("Subscribe", _channelName);
                lblStatus.Text = "Connected!";
                ptbStatus.Image = Resources.PogChamp;
            }
            catch (Exception)
            {
                ptbStatus.Image = Resources.DansGame;
                var r = MessageBox.Show("Connection failed! Press Retry to try again or Cancel to Quit.", "Connection failed", MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error);
                if (r == DialogResult.Retry)
                {
                    FrmMain_Shown(sender, e);
                }
                else
                {
                    Application.Exit();
                }
            }

        }
        private void HandleHex(string sender, bool isSub, string hex)
        {
            if (!cbEnabled.Enabled) return;
            if (cbEnabled.Enabled && !isSub) return;
            try
            {
                _commands.SetColor(new RGBColor(hex));
                lbCommands.BeginUpdate();
                lbCommands.Items.Add($"{sender}: Color change:{hex}");
                lbCommands.EndUpdate();
            }
            catch (Exception)
            {
                // Ignored
            }

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            while (string.IsNullOrWhiteSpace(_channelName))
                _channelName = Prompt.ShowDialog("Please enter the channel name you want to monitor.", "Channel Name");
        }

        private async void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            await _connection.DisposeAsync();
            Application.Exit();
        }
    }
}
