using MyDiary.Services.Records;
using MyDiary.Services.Settings;
using MyDiary.ViewModels;

namespace MyDiary;

public partial class PasswordInputPage : ContentPage
{
	private readonly IRecordService _recordService;
	private readonly IServiceProvider _serviceProvider;

	public PasswordInputPage(
            IRecordService recordService,
            ISettingService settingService,
            IServiceProvider serviceProvider
        )
	{
		_recordService = recordService;

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