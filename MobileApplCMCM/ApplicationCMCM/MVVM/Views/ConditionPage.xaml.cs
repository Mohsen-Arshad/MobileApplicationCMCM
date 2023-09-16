using ApplicationCMCM.MVVM.ViewModels;
using CommunityToolkit.Mvvm.Input;

namespace ApplicationCMCM.MVVM.Views;

public partial class ConditionPage : ContentPage
{
	public ConditionPage(ConditionPageViewModel conditionPageViewModel)
	{
		InitializeComponent();
		BindingContext = conditionPageViewModel;
	}
}