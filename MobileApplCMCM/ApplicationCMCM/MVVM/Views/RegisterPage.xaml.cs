using ApplicationCMCM.MVVM.ViewModels;

namespace ApplicationCMCM.MVVM.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterPageViewModel registerPageViewModel)
	{
		InitializeComponent();
		BindingContext = registerPageViewModel;
	}
}