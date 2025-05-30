﻿using Core.Db;
using Core.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Foldable;
using MyDiary.Extensions;

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
                .RegisterViews();

            builder.Services.RegisterDb();
            builder.Services.RegisterServices();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            var app = builder.Build();

            app.Services.MigrateDb();

            return app;
        }
    }
}
