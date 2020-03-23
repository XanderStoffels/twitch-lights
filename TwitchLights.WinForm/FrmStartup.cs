using Q42.HueApi;
using Q42.HueApi.Models.Bridge;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchLights.WinForm
{
    public partial class FrmStartup : Form
    {
        private List<LocatedBridge> _bridges;
        public FrmStartup()
        {
            InitializeComponent();
            this._bridges = new List<LocatedBridge>();
        }

        private async void FormStartup_Load(object sender, EventArgs e)
        {
#if DEBUG
            MessageBox.Show("Debug mode!");
#endif
            // Check if the user has internet connection.
            try
            {
                var result = await new Ping().SendPingAsync("www.google.com");
            }
            catch (Exception)
            {
                lblTitle.Text = "Internet error";
                lbBridges.Visible = false;
                lblProcessTime.Visible = false;
                lblDescribtion.Text = "No internet connection detected.\nPlease try again when internet is available.";
                return;
            }

            // Detect local network bridges.
            var locator = new HttpBridgeLocator();
            var bridges = await locator.LocateBridgesAsync(TimeSpan.FromSeconds(5));
            this._bridges = bridges.ToList();

            // Check for a local emulator.
            if (!_bridges.Any())
            {
                try
                {
                    var http = new HttpClient();
                    var x = await http.GetAsync("http://localhost/api");
                    if (x.IsSuccessStatusCode)
                    {
                        _bridges.Add(new LocatedBridge { BridgeId = "hue_dev_emulator", IpAddress = "localhost" });
                    }
                }
                catch (Exception)
                { /* Ignored */ }
            }

            if (!_bridges.Any())
            {
                lblTitle.Text = "Bridge error";
                lbBridges.Visible = false;
                lblProcessTime.Visible = false;
                lblDescribtion.Text = "No Bridges detected.\nMake sure your bridge is plugged in\nand connected to the local network.";
                return;
            }

            lbBridges.BeginUpdate();
            foreach (var bridge in _bridges)
                this.lbBridges.Items.Add(bridge.IpAddress);
          
            lbBridges.EndUpdate();
            lbBridges.Enabled = true;
            lbBridges.Visible = true;
        }

        private void LbBridges_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lbBridges.SelectedIndex == -1) return;
            var selectedBridge = _bridges[lbBridges.SelectedIndex];
            var frm = new FrmHandshake(selectedBridge)
            {
                StartPosition = FormStartPosition.Manual,
                Location = this.Location
            };
            frm.Show();
            this.Hide();
        }
    }
}
