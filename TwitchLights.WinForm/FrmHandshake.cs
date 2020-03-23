using Q42.HueApi;
using Q42.HueApi.Interfaces;
using Q42.HueApi.Models.Bridge;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwitchLights.WinForm.Data;

namespace TwitchLights.WinForm
{
    public partial class FrmHandshake : Form
    {
        private readonly LocatedBridge _bridge;
        private ILocalHueClient _client;
        public FrmHandshake(LocatedBridge bridge)
        {
            InitializeComponent();
            this._bridge = bridge;
            this.ptbBanner.Image = Properties.Resources.mode_hue;
        }

        private async void FrmHandshake_Load(object sender, EventArgs e)
        {
            var store = new Store();
            await store.CreateDirectoriesAsync();

            var info = await store.GetAsync(_bridge.BridgeId);
            if (info == null)
            {
                lblStatus.Text = "Pairing required";
                InstructionsVisible(true);
                return;
            }

            var client = new LocalHueClient(_bridge.IpAddress);
            client.Initialize(info.Key);
            this._client = client;
            LightSetup();

        }

        private async void btnPressed_Click(object sender, EventArgs e)
        {
            var client = new LocalHueClient(_bridge.IpAddress);
            var store = new Store();
            try
            {
                var key = await client.RegisterAsync("TwitchLights", $"{Environment.MachineName}/{Environment.UserName}".Substring(0,18));
                client.Initialize(key);
                this._client = client;
                await store.AddOrUpdateAsync(new KeyStoreEntry { HubId = _bridge.BridgeId, Key = key });
                await store.SaveAsync();
                LightSetup();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Paring failed. " + ex.Message, "Unable to pair.");
            }
        }
        
        private void LightSetup()
        {
            if (_client == null) return;
            var frm = new FrmLightSetup(_client)
            {
                StartPosition = FormStartPosition.Manual,
                Location = this.Location
            };
            frm.Show();
            this.Hide();
        }

        private void InstructionsVisible(bool b)
        {
            lblInstructions.Visible = b;
            ptbLink.Visible = b;
            btnPressed.Visible = b; 
        }

        private void FrmHandshake_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }
    }
}
