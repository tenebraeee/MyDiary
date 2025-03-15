using MyDiary.Services.Records;
using MyDiary.Services.Settings;
using MyDiary.ViewModels;

namespace MyDiary;

public partial class PasswordInputPage : ContentPage
{
	private readonly IServiceProvider _serviceProvider;


	public PasswordInputPage(
            ISettingService settingService,
            IServiceProvider serviceProvider
        )
	{
        InitializeComponent();

		_serviceProvider = serviceProvider;

        BindingContext = new PasswordInputViewModel(settingService, OnCorrectPasswordEntered);
	}


	public void OnCorrectPasswordEntered()
	{
		var mainPage = _serviceProvider.GetRequiredService<MainPage>();

        Navigation.PushAsync(mainPage);
	}
}