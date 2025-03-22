#if WINDOWS
using Microsoft.UI;
using WinRT.Interop;
#endif

using MyDiary.ViewModels;
using MyDiary.Pages;

namespace MyDiary
{
    public partial class MainPage : ContentPage
    {
        private readonly IViewFactory _viewFactory;


        public MainPage(
                IViewFactory viewFactory,
                DiaryViewModel viewModel
            )
        {
            InitializeComponent();

            _viewFactory = viewFactory;

            BindingContext = viewModel;
        }


        protected override void OnHandlerChanged()
        {
#if WINDOWS
            var nativeWindow = (Microsoft.UI.Xaml.Window)Application.Current.Windows.FirstOrDefault()?.Handler?.PlatformView;
            var hWnd = WindowNative.GetWindowHandle(nativeWindow);
            var windowId = Win32Interop.GetWindowIdFromWindow(hWnd);
            var handle = WindowNative.GetWindowHandle(nativeWindow);
            var id = Win32Interop.GetWindowIdFromWindow(handle);
            var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(id);

            appWindow.Closing += async (s, e) =>
            {
                e.Cancel = true;

                var viewModel = (DiaryViewModel)BindingContext;

                if (!viewModel.IsSaved)
                {
                    var result =
                        await DisplayAlert("Выход из программы", "Есть несохраненные записи. Вы действительно хотите выйти из программы?", "ОК", "Отмена");

                    if (result)
                    {
                        Application.Current.Quit();
                    }
                }
                else
                {
                    Application.Current.Quit();
                }
            };
#endif
        }

        private async void MenuFlyoutItem_Clicked(object sender, EventArgs e)
        {
            if (Handler == null)
            {
                return;
            }

            await Navigation.PushAsync(_viewFactory.Get<SettingsPage>());
        }
    }
}
