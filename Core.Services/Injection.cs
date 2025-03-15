using Microsoft.Extensions.DependencyInjection;
using MyDiary.Services.Records;
using MyDiary.Services.Settings;

namespace Core.Services
{
    public static class Injection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IRecordService, RecordService>();
            services.AddScoped<ISettingService, SettingService>();

            return services;
        }
    }
}
