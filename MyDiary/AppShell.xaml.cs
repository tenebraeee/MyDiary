namespace MyDiary
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(PageRoutes.Main, typeof(MainPage));
            Routing.RegisterRoute(PageRoutes.PasswordInput, typeof(PasswordInputPage));
            Routing.RegisterRoute(PageRoutes.Settings, typeof(SettingsPage));
        }
    }

    public static class PageRoutes
    {
        public static readonly string Main = nameof(MainPage);
        public static readonly string PasswordInput = nameof(PasswordInputPage);
        public static readonly string Settings = nameof(SettingsPage);
    }
}
