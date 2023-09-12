using ApplicationCMCM.CustomConstants;
using ApplicationCMCM.MVVM.Views;
using ApplicationCMCM.Services;
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

    [RelayCommand]
    async Task CallEmergenciesAsync()
    {
        try
        {
            IsBusy = true;
            //var status = PermissionStatus.Unknown;
            //status = await Permissions.CheckStatusAsync<Permissions.Phone>();
            //if (status == PermissionStatus.Granted)
            //{
            //    PhoneDialer.Open(CustomConst.EmergencyNumber);
            //    return;
            //}

            //if (Permissions.ShouldShowRationale<Permissions.Phone>())
            //{
            //    await Shell.Current.DisplayAlert("Needs permissions",
            //        $"If you want to call emergencies you have to grant access or call following number {CustomConst.EmergencyNumber}",
            //        "Ok");
            //}

            //status = await Permissions.RequestAsync<Permissions.Phone>();

            //if (status != PermissionStatus.Granted)
            //{
            //    await Shell.Current.DisplayAlert("Permission required",
            //        "Access phone and call permission is required for calling emergency",
            //        "Ok");
            //}
            CustomServices.CallingEmergencyFunction();
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
