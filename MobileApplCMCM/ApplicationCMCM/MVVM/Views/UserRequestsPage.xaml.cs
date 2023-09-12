using ApplicationCMCM.MVVM.ViewModels;

namespace ApplicationCMCM.MVVM.Views;

public partial class UserRequestsPage : ContentPage
{
	public UserRequestsPage(UserRequestsPageViewModel userRequestsPageViewModel)
	{
		InitializeComponent();
		BindingContext = userRequestsPageViewModel;
	}
}