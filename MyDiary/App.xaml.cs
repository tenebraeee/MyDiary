using MyDiary.Pages;
using MyDiary.Services.Settings;

namespace MyDiary
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IViewFactory _viewFactory;


        public App(
                IServiceProvider serviceProvider,
                IViewFactory viewFactory
            )
        {
            _serviceProvider = serviceProvider;
            _viewFactory = viewFactory;

            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        }


        protected override Window CreateWindow(IActivationState? activationState)
        {
            var settingService = _serviceProvider.GetRequiredService<ISettingService>();
            var setting = settingService.Get();

            var page = default(Page);
            if (setting.IsPasswordDefined)
            {
                page = _viewFactory.Get<PasswordInputPage>();
            }
            else
            {
                page = _viewFactory.Get<MainPage>();
            }

            var window = new Window(new AppShell())
            {
                Page = new NavigationPage(page),
            };
            return window;
        }
    }
}