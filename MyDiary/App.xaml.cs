using MyDiary.Services.Settings;

namespace MyDiary
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;


        public App(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }


        protected override Window CreateWindow(IActivationState? activationState)
        {
            var settingService = _serviceProvider.GetRequiredService<ISettingService>();
            var setting = settingService.Get();

            var page = default(Page);
            if (setting.IsPasswordDefined)
            {
                page = _serviceProvider.GetRequiredService<PasswordInputPage>();
            }
            else
            {
                page = _serviceProvider.GetRequiredService<MainPage>();
            }

            var window = new Window(new AppShell())
            {
                Page = new NavigationPage(page),
            };
            return window;
        }
    }
}