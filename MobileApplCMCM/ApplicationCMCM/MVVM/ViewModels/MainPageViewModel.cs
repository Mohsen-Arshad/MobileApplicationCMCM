using ApplicationCMCM.MVVM.Views;
using CommunityToolkit.Mvvm.Input;

namespace ApplicationCMCM.MVVM.ViewModels;

public partial class MainPageViewModel : BaseViewModel
{
    public MainPageViewModel()
    {
        Title = "Main Page";
    }

    [RelayCommand]
    async Task GoToUserPanelAsync()
    {
        try
        {
            IsBusy = true;
            await Shell.Current.GoToAsync(nameof(UserPanelPage));
        }
        catch (Exception)
        {
            await Shell.Current.DisplayAlert("Alert", "Something went wrong", "Ok");
        }
        finally 
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task GoToCategoriesAsync()
    {
        try
        {
            IsBusy = true;
            await Shell.Current.GoToAsync(nameof(CategoriesPage));
        }
        catch (Exception)
        {
            await Shell.Current.DisplayAlert("Alert", "Something went wrong", "Ok");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task GoToUserRequestsAsync()
    {
        try
        {
            IsBusy = true;
            await Shell.Current.GoToAsync(nameof(UserRequestsPage));
        }
        catch (Exception)
        {
            await Shell.Current.DisplayAlert("Alert", "Something went wrong", "Ok");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task GoToPharmaciesAsync()
    {
        try
        {
            IsBusy = true;
            await Shell.Current.GoToAsync(nameof(PharmaciesPage));
        }
        catch (Exception)
        {
            await Shell.Current.DisplayAlert("Alert", "Something went wrong", "Ok");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
