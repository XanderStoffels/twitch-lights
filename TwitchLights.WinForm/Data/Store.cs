using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TwitchLights.WinForm.Data
{
    public class Store
    {
        private readonly DirectoryInfo _appDir;
        private readonly FileInfo _keyStore;
        private List<KeyStoreEntry> _store;

        public Store()
        {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TwitchLights";
            _appDir = new DirectoryInfo(dir);
            _keyStore = new FileInfo(dir + "\\keystore.json");
        }

        public async Task CreateDirectoriesAsync()
        {
            if (!_appDir.Exists)
                _appDir.Create();

            if (!_keyStore.Exists)
            {
                using var stream = _keyStore.Create();
                await JsonSerializer.SerializeAsync(stream, new List<KeyStoreEntry>());
                await stream.FlushAsync();
                stream.Close();
            }
        }

        public async Task<KeyStoreEntry> GetAsync(string hubId)
        {
            if (_store == null)
            {
                using var stream = _keyStore.OpenRead();
                _store = await JsonSerializer.DeserializeAsync<List<KeyStoreEntry>>(stream);
            }

            return _store.FirstOrDefault(s => s.HubId == hubId);
        }

        public async Task<KeyStoreEntry> AddOrUpdateAsync(KeyStoreEntry entry)
        {
            if (_store == null)
            {
                using var stream = _keyStore.OpenRead();
                _store = await JsonSerializer.DeserializeAsync<List<KeyStoreEntry>>(stream);
            }
            var old = _store.FirstOrDefault(k => k.HubId == entry.HubId);
            if (old != null) _store.Remove(old);
            _store.Add(entry);
            return entry;
        }

        public async Task SaveAsync()
        {

            File.WriteAllText(_keyStore.FullName, string.Empty);
            using var stream = _keyStore.OpenWrite();
            await JsonSerializer.SerializeAsync(stream, _store);
            await stream.FlushAsync();
        }
    }
}
