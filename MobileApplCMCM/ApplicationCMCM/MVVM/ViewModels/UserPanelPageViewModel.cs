using ApplicationCMCM.MVVM.Models;
using ApplicationCMCM.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace ApplicationCMCM.MVVM.ViewModels;

public partial class UserPanelPageViewModel : BaseViewModel
{
    private readonly ApiServices _apiServices;
    private readonly IConnectivity _connectivity;
    [ObservableProperty]
    private UserModel userInformationModel = new();

    public UserPanelPageViewModel(ApiServices apiServices, IConnectivity connectivity)
    {
        _apiServices = apiServices;
        _connectivity = connectivity;
        GetUserInfoCommand.Execute(this);
    }

    [RelayCommand]
    async Task GetUserInfo()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {

                await Shell.Current.DisplayAlert("Internet Issue", $"Please check your internet connection and try again!", "Ok");
                return;
            }
            IsBusy = true;

            var userId = Preferences.Get("userid", "default_value");
            UserInformationModel = await _apiServices.UserInfo(int.Parse(userId));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Alert", "Something went wrong", "Ok");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task UpdateUser()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = true;
            var result = await _apiServices.UpdateUser(UserInformationModel);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Alert", "Something went wrong", "Ok");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task BackToMainPage()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = true;
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Alert", "Something went wrong", "Ok");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
