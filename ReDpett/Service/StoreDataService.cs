using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ReDpett.Modal;
using SQLite;


namespace ReDpett.Service
{
    public class StoreDataService : ISaveDataService
    {
        private SQLiteConnection conn;
        private static string applicationFolderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "TestApp");
        string databaseFileName = Path.Combine(applicationFolderPath, "TestApp.db");

        public void CreateOfflineDB(AppDataService appData)
        {
            var db = new SQLiteConnection(databaseFileName);
           
            var table = db.GetTableInfo("AppDataService").FirstOrDefault();
            db.Insert(appData);
            List<AppDataService> users = db.Table<AppDataService>().ToList();

        }

    }
}
