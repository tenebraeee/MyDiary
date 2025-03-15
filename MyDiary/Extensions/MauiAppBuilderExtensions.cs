namespace MyDiary.Extensions
{
    public static class MauiAppBuilderExtensions
    {
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<PasswordInputPage>();
            builder.Services.AddTransient<SettingsPage>();

            return builder;
        }

        public static MauiAppBuilder RegisterModels(this MauiAppBuilder builder)
        {
            return builder;
        }
    }
}
