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
        //private static string applicationFolderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "TestApp");
        //string databaseFileName = Path.Combine(applicationFolderPath, "TestApp.db");
        string databaseFileName = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MyData.db");

        public async void CreateOfflineDB()
        {
            var db = new SQLiteAsyncConnection(databaseFileName);

            await db.CreateTableAsync<Project>();

        }

        public string InsertOfflineDB()
        {
            var db = new SQLiteConnection(databaseFileName);

            if( db.GetTableInfo("Project").Count > 0)
            {
                return db.GetTableInfo("Project").FirstOrDefault().Name;
            }
            else
            {
                return null;
            }

            //db.Insert(appData);
            //List<AppDataService> users = db.Table<AppDataService>().ToList();

        }

    }
}
