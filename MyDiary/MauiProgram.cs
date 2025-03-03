using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyDiary.Extensions;
using Microsoft.Maui.Foldable;
using MyDiary.Db.Contexts;
using MyDiary.Db;

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
                .Services.RegisterDb($"Data Source={Path.Combine(FileSystem.AppDataDirectory, "diary.db")}"); //todo: вынести в метод расширения
            
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
