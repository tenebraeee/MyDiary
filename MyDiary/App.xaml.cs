using Core.Db.Contexts;
using MyDiary.Services.Records;
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
            if (string.IsNullOrWhiteSpace(setting.Password))
            {
                page = new MainPage(
                        _serviceProvider.GetRequiredService<SqlContext>(),
                        _serviceProvider.GetRequiredService<IRecordService>()
                    );
            }
            else
            {
                page = new PasswordInputPage(
                        _serviceProvider.GetRequiredService<SqlContext>(),
                        _serviceProvider.GetRequiredService<IRecordService>(),
                        _serviceProvider.GetRequiredService<ISettingService>()
                    );
            }

            var window = new Window(new AppShell())
            {
                Page = new NavigationPage(page),
            };
            return window;
        }
    }
}