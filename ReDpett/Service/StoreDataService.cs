using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Datasync.Client;
using Microsoft.Datasync.Client.SQLiteStore;

namespace ReDpett.Service
{
    public class StoreDataService : ISaveDataService
    {
        private IOfflineTable<AppDataService> _table;
        public string OfflineDb { get; set; }

        public async void CreateOfflineDB()
        {
            //var connectionString = new UriBuilder { Scheme = "file", Path = OfflineDb, Query = "?mode=rwc" }.Uri.ToString();
            var store = new OfflineSQLiteStore("file:///offline.db?mode=rwc");
            store.DefineTable<AppDataService>();

            var options = new DatasyncClientOptions { OfflineStore = store };

            var _client = new DatasyncClient("Server=localhost\\SQLEXPRESS;Database=TVSHOW;Trusted_Connection=True", options);

            await _client.InitializeOfflineStoreAsync();

            _table = _client.GetOfflineTable<AppDataService>();
        }

    }
}
