using ApplicationCMCM.MVVM.ViewModels;

namespace ApplicationCMCM.MVVM.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel mainPageViewModel)
	{
		InitializeComponent();
        BindingContext = mainPageViewModel;
	}

    protected override bool OnBackButtonPressed()
    {
		return true;
    }
}