using MyDiary.Pages;
using MyDiary.Pages.Behaviours;
using MyDiary.ViewModels;

namespace MyDiary.Extensions
{
    public static class MauiAppBuilderExtensions
    {
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<IViewFactory, ViewFactory>();
            builder.Services.AddTransient<ICorrectPasswordEneteredBehaviour, CorrectPasswordEneteredBehaviour>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<PasswordInputPage>();
            builder.Services.AddTransient<SettingsPage>();

            return builder;
        }

        public static MauiAppBuilder RegisterModels(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<DiaryViewModel>();
            builder.Services.AddTransient<PasswordInputViewModel>();
            builder.Services.AddTransient<SettingsViewModel>();

            return builder;
        }
    }
}
