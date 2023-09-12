using ApplicationCMCM.MVVM.ViewModels;

namespace ApplicationCMCM.MVVM.Views;

public partial class PharmaciesPage : ContentPage
{
	public PharmaciesPage(PharmaciesPageViewModel pharmaciesPageViewModel)
	{
		InitializeComponent();
		BindingContext = pharmaciesPageViewModel;
	}
}