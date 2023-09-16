using ApplicationCMCM.MVVM.Models;
using ApplicationCMCM.MVVM.Views;
using ApplicationCMCM.Services;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Windows.Input;

namespace ApplicationCMCM.MVVM.ViewModels;

public partial class RegisterPageViewModel : BaseViewModel
{
    private readonly ApiServices _apiServices;
    IConnectivity _connectivity;
    public RegisterModel Register { get; set; } = new RegisterModel();

    public RegisterPageViewModel(ApiServices apiServices, IConnectivity connectivity)
    {
        Title = "Register";
        _apiServices = apiServices;
        _connectivity = connectivity;
    }

    [RelayCommand]
    async Task RegisterUserAsync()
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
            var result = await _apiServices.RegisterUser(Register);
            if (result)
            {
                // go to login page
                await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", $"Unable to create request", "Ok");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", $"Unable to create user", "Ok");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task GoToLoginPageAsync()
    {
        await Shell.Current.GoToAsync(nameof(LoginPage));
    }
}
