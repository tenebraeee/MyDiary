using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyDiary.Db;
using MyDiary.Extensions;
using Microsoft.Maui.Foldable;

namespace MyDiary
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseFoldable()
                .RegisterModels()
                .RegisterServices()
                .RegisterViews()
                .Services.AddDbContext<SqlContext>(o => 
                {
                    o.UseSqlite($"Data Source={Path.Combine(FileSystem.AppDataDirectory, "diary.db")}");
                }); //todo: вынести в метод расширения
            
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
