using MyDiary.Pages;
using MyDiary.ViewModels;

namespace MyDiary;

public partial class PasswordInputPage : ContentPage
{
	private readonly IViewFactory _viewFactory;


	public PasswordInputPage(
            IViewFactory viewFactory,
			PasswordInputViewModel viewModel
        )
	{
        InitializeComponent();

        _viewFactory = viewFactory;
		viewModel.OnCorrectPasswordEntered = OnCorrectPasswordEntered;
        BindingContext = viewModel;
	}


	public void OnCorrectPasswordEntered()
	{
		var mainPage = _viewFactory.Get<MainPage>();

        Navigation.PushAsync(mainPage);
	}
}
