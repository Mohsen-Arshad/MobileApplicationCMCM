using ApplicationCMCM.MVVM.ViewModels;

namespace ApplicationCMCM.MVVM.Views;

public partial class PopupPage
{

    public PopupPage()
	{
		InitializeComponent();
		BindingContext = new PopupPageViewModel();
	}
}