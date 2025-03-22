using MyDiary.ViewModels;

namespace MyDiary;

public partial class PasswordInputPage : ContentPage
{
	public PasswordInputPage(
			PasswordInputViewModel viewModel
        )
	{
        InitializeComponent();

        BindingContext = viewModel;
	}
}
