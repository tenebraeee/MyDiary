using MyDiary.Services.Settings;
using MyDiary.ViewModels;

namespace MyDiary;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(ISettingService settingService)
	{
		InitializeComponent();

		BindingContext = new SettingsViewModel(settingService);
    }
}