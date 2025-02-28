using MyDiary.Db;
using MyDiary.Services.Records;
using MyDiary.Services.Settings;
using MyDiary.ViewModels;

namespace MyDiary;

public partial class PasswordInputPage : ContentPage
{
	private readonly SqlContext _context;
	private readonly IRecordService _recordService;

	public PasswordInputPage(
            SqlContext context,
            IRecordService recordService,
            ISettingService settingService
        )
	{
		_context = context;
		_recordService = recordService;

        InitializeComponent();

		BindingContext = new PasswordInputViewModel(settingService, OnCorrectPasswordEntered);
	}

	public void OnCorrectPasswordEntered()
	{
		Navigation.PushAsync(new MainPage(_context, _recordService));
	}
}