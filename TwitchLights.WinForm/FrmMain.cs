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
using TwitchLights.Lib.SignalR;
using TwitchLights.WinForm.Properties;

namespace TwitchLights.WinForm
{
    public partial class FrmMain : Form
    {
        private readonly List<string> _lights;
        private readonly HubForClient _hub;
        private readonly Commands _commands;
        private readonly ILocalHueClient _hue;
        private string _channelName;

        public FrmMain(ILocalHueClient hueClient, List<string> lightIds)
        {
            InitializeComponent();
            this._lights = lightIds;
            this._hue = hueClient;

            this._hub = new HubForClient();
            this._hub.ReceiveHex += ReceiveHex;
            this._hub.ReceiveInfoEvent += ReceiveInfoEvent;
            this._hub.ReceivePingEvent += ReceivePingEvent;
            this._hub.ReceiveLeaveEvent += ReceiveLeaveEvent;
            this._hub.ReceiveErrorEvent += ReceiveErrorEvent;
            this._hub.ReceiveJoinEvent += ReceiveJoinEvent;
            this._hub.ReceiveRoutine += ReceiveRoutine;
            this._hub.ReceiveUserRoutine += ReceiveUserRoutine;

            _commands = new Commands(_hue, lightIds);
        }

        // Event handlers
        private void ReceiveUserRoutine(string routine, UserContext user)
        {
            WriteLog($"{user.Username}: Routine : {routine}");
        }

        private void ReceiveRoutine(string routine)
        {
            WriteLog($"Routine : {routine}");
        }

        private void ReceiveJoinEvent(int count)
        {
            WriteLog($"Light user joined! [{count}]");
        }

        private void ReceiveErrorEvent(string error)
        {
            MessageBox.Show(error, "Server error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ReceiveLeaveEvent(int count)
        {
            WriteLog($"Light user left! [{count}]");
        }

        private void ReceivePingEvent(string status)
        {
            if (status == "PING")
                lblHealthCheck.Text = DateTime.Now.ToLongTimeString();
        }

        private void ReceiveInfoEvent(string info)
        {
            MessageBox.Show(info, "Message from server", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ReceiveHex(UserContext user, string hex)
        {
            if (!cbEnabled.Checked) return;
            if (cbSubOnly.Checked && !user.IsSub) return;
            try
            {
                _commands.SetColor(new RGBColor(hex));
                this.WriteLog($"{user.Username} : Color : {hex}");
            }
            catch (Exception)
            {
                // Ignored
            }
        }

        // Form events
        private void FrmMain_Load(object sender, EventArgs e)
        {
            while (string.IsNullOrWhiteSpace(_channelName))
                _channelName = Prompt.ShowDialog("Please enter the channel name you want to monitor.", "Channel Name");
        }
        private async void FrmMain_Shown(object sender, EventArgs e)
        {
            ptbStatus.Image = Resources.ReisdentSleeper;

            try
            {
                await _hub.StartAsync();
                await _hub.Subscribe(_channelName);
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
        private async void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            await _hub.StopAsync();
            Application.Exit();
        }

        // Helpers
        private void WriteLog(string message)
        {
            lbCommands.BeginUpdate();
            lbCommands.Items.Add(message);
            lbCommands.EndUpdate();
        }
    }
}
