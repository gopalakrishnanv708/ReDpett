using ReDpett.Data;
using ReDpett.Modal;
using ReDpett.Service;
using SQLite;

namespace ReDpett;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });
        builder.Services.AddScoped(client =>
   new HttpClient
   {
       Timeout = TimeSpan.FromSeconds(15),

   });
        builder.Services.AddMauiBlazorWebView();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif
        builder.Services.AddSingleton<AppDataService>();
        builder.Services.AddSingleton<WeatherForecastService>();
        builder.Services.AddScoped<ISaveDataService, StoreDataService>();

        // Get an absolute path to the database file
        

        
        //string applicationFolderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "TestApp");
        //if (!Directory.Exists(applicationFolderPath))
        //{
        //    Directory.CreateDirectory(applicationFolderPath);
        //}
        //string databaseFileName = Path.Combine(applicationFolderPath, "TestApp.db");

        //if (!File.Exists(databasePath))
        //{
        //    var db = new SQLiteAsyncConnection(databasePath);

        //     db.creat
        //    //var db = new SQLiteConnection(databaseFileName);
        //    //db.CreateTable<Project>();

        //}

        return builder.Build();
    }
}
