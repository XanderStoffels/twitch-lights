using Q42.HueApi;
using Q42.HueApi.ColorConverters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Q42.HueApi.ColorConverters.Original;
using Q42.HueApi.Interfaces;

namespace TwitchLights.WinForm
{
    public class Commands
    {
        private readonly ILocalHueClient _client;
        private readonly List<string> _lights = new List<string>();

        public Commands(ILocalHueClient client, List<string> lights)
        {
            _client = client;
            _lights = lights;
        }

        public Task Cycle()
        {
            var cycle = new LightCommand
            {
                On = true,
                Effect = Effect.ColorLoop
            };
            return _client.SendCommandAsync(cycle, _lights);
        }

        public Task On()
        {
            var cmd = new LightCommand
            {
                On = true
            };
            return _client.SendCommandAsync(cmd, _lights);
        }

        public Task Off()
        {
            var cmd = new LightCommand
            {
                On = false
            };
            return _client.SendCommandAsync(cmd, _lights);
        }

        public Task StopCycle()
        {
            var cancel = new LightCommand
            {
                Effect = Effect.None
            };
            return _client.SendCommandAsync(cancel, _lights);
        }

        public async Task CycleFor(int ms)
        {
            await Cycle();
            await Task.Delay(ms);
            await StopCycle();
        }

        public Task Blink()
        {
            var cancel = new LightCommand
            {
                On = true,
                Alert = Alert.Multiple
            };
            return _client.SendCommandAsync(cancel, _lights);
        }

        public Task StopBlinking()
        {
            var cancel = new LightCommand
            {
                Alert = Alert.None
            };
            return _client.SendCommandAsync(cancel, _lights);
        }

        public Task SetColor(RGBColor color)
        {

            var cmd = new LightCommand()
                .TurnOn()
                .SetColor(color);
            return _client.SendCommandAsync(cmd, _lights);
        }
    }
}
