using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Extensions.DependencyInjection;
using ReDpett.Data;
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

        builder.Services.AddMauiBlazorWebView();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif
        builder.Services.AddSingleton<AppDataService>();
        builder.Services.AddSingleton<WeatherForecastService>();
        builder.Services.AddScoped<ISaveDataService, StoreDataService>();
        builder.Services.AddScoped<IDBService, DBService>();

        //string applicationFolderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "TestApp");
        //if (!Directory.Exists(applicationFolderPath))
        //{
        //    Directory.CreateDirectory(applicationFolderPath);
        //}
        //string databaseFileName = Path.Combine(applicationFolderPath, "TestApp.db");

        //if (!File.Exists(databaseFileName))
        //{
        //    var db = new SQLiteConnection(databaseFileName);
        //    db.CreateTable<AppDataService>();

        //}

        return builder.Build();
    }
}
