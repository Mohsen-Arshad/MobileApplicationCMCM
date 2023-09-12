using ApplicationCMCM.MVVM.ViewModels;

namespace ApplicationCMCM.MVVM.Views;

public partial class CategoriesPage : ContentPage
{
	public CategoriesPage(CategoriesPageViewModel categoriesPageViewModel)
	{
		InitializeComponent();
		BindingContext = categoriesPageViewModel;
	}
}