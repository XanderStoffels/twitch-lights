using Q42.HueApi;
using Q42.HueApi.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TwitchLights.WinForm
{
    public partial class FrmLightSetup : Form
    {
        private readonly ILocalHueClient _client;
        private List<Light> _lights;
        private HashSet<int> _oldSelected;
        public FrmLightSetup(ILocalHueClient client)
        {
            InitializeComponent();
            this._client = client;
            this._lights = new List<Light>();
            _oldSelected = new HashSet<int>();
        }

        private async void FrmLightSetup_Load(object sender, EventArgs e)
        {
            this.Text += $" {Application.ProductVersion}";
            _lights = (await _client.GetLightsAsync()).ToList();
            foreach (var light in _lights)
            {
                lbLights.Items.Add(light.Name);
            }
        }

        private void lbLights_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cmdOn = new LightCommand()
            {
                Alert = Alert.Once
            };
            var selected = lbLights.SelectedIndices.Cast<int>().ToList();

            var newAdded = selected.Except(_oldSelected).ToList();
            _oldSelected = selected.ToHashSet();

            if (newAdded.Count == 0)
                return;

            var ids = newAdded.Select(i => _lights[i].Id).ToList();    
            _client.SendCommandAsync(cmdOn, ids);
            _oldSelected = selected.ToHashSet();

            btnGo.Enabled = _oldSelected.Count != 0;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            var ids = _oldSelected.Select(i => _lights[i].Id).ToList();
            var frm = new FrmMain(_client, ids)
            {
                StartPosition = FormStartPosition.Manual,
                Location = this.Location
            };
            frm.Show();
            this.Hide();
        }

        private void FrmLightSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
