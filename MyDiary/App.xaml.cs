using MyDiary.Services.Settings;

namespace MyDiary
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;


        public App(
                IServiceProvider serviceProvider
            )
        {
            _serviceProvider = serviceProvider;

            InitializeComponent();
        }


        protected override Window CreateWindow(IActivationState? activationState)
        {
            var settingService = _serviceProvider.GetRequiredService<ISettingService>();
            var setting = settingService.Get();

            var shell = new AppShell();
            if (setting.IsPasswordDefined)
            {
                shell.GoToAsync("PasswordInputPage");
            }
            else
            {
                shell.GoToAsync("MainPage");
            }
            
            var window = new Window(shell)
            {
                Page = shell,
            };

            return window;
        }
    }
}