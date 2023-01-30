﻿using Newtonsoft.Json;

namespace ReDpett.Service
{
    public class StoreDataService : ISaveDataService
    {
        string applicationFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "TestApp");
        
        private ListAppDataService _data;

        public StoreDataService(ListAppDataService data)
        {
            _data = data;
        }

        public async Task<ListAppDataService> GetDataFromOfflineDB()
        {
            try
            {
                if (!Directory.Exists(applicationFolderPath))
                {
                    Directory.CreateDirectory(applicationFolderPath);
                }
                string databaseFileName = Path.Combine(applicationFolderPath, "Projects.json");

                var str = File.ReadAllText(databaseFileName);
                if (!String.IsNullOrEmpty(str))
                {
                    var listAppDataService = JsonConvert.DeserializeObject<ListAppDataService>(str);
                    _data = listAppDataService;
                }
                
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Alert!", "Data was retrived from local db. Error Occured.." + ex.Message, "OK");
            }
            return _data;
        }

        public async void InsertOfflineDB()
        {
            try
            {
                if (!Directory.Exists(applicationFolderPath))
                {
                    Directory.CreateDirectory(applicationFolderPath);
                }
                string databaseFileName = Path.Combine(applicationFolderPath, "Projects.json");

                

                string req_json_string = JsonConvert.SerializeObject(_data);
                File.WriteAllText(databaseFileName, req_json_string);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Alert!", "Data was not saved in local db. Error Occured.." + ex.Message, "OK");
            }
        }

    }
}
