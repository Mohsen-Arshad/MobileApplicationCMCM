using ApplicationCMCM.MVVM.ViewModels;

namespace ApplicationCMCM.MVVM.Views;

public partial class UserPanelPage : ContentPage
{
	public UserPanelPage(UserPanelPageViewModel userPanelPageViewModel)
	{
		InitializeComponent();
		BindingContext = userPanelPageViewModel;
	}
}