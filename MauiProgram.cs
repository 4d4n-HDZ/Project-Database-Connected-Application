using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using OOP_final.Components.Data;
using SQLitePCL;

namespace OOP_final
{
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
            builder.Logging.AddDebug();
#endif

           
            var dbName = "employees.db";
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, dbName);

            builder.Services.AddDbContextFactory<AppDbContext>(options =>
                options.UseSqlite($"Data Source={dbPath}"));

            
            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var dbFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();
                using var db = dbFactory.CreateDbContext();
                db.Database.EnsureCreated();
                DbSeeder.Seed(db);
            }

            return app;
        }
    }
}

