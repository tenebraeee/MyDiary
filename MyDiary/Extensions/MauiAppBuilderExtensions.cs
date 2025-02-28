using MyDiary.Services.Records;
using MyDiary.Services.Settings;

namespace MyDiary.Extensions
{
    public static class MauiAppBuilderExtensions
    {
        public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddScoped<IRecordService, RecordService>();
            builder.Services.AddScoped<ISettingService, SettingService>();

            return builder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            return builder;
        }

        public static MauiAppBuilder RegisterModels(this MauiAppBuilder builder)
        {
            return builder;
        }
    }
}
