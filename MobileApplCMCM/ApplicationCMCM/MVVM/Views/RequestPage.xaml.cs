using ApplicationCMCM.MVVM.ViewModels;

namespace ApplicationCMCM.MVVM.Views;

public partial class RequestPage : ContentPage
{
	public RequestPage(RequestPageViewModel requestPageViewModel)
	{
		InitializeComponent();
		BindingContext = requestPageViewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}