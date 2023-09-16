using ApplicationCMCM.MVVM.Models;
using ApplicationCMCM.MVVM.Views;
using ApplicationCMCM.Services;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace ApplicationCMCM.MVVM.ViewModels;

public partial class LoginPageViewModel : BaseViewModel
{
    private readonly ApiServices _apiServices;
    private readonly IConnectivity _connectivity;

    public LoginModel Login { set; get; } = new LoginModel();

    public LoginPageViewModel(ApiServices apiServices, IConnectivity connectivity)
    {
        Title = "Login";
        _apiServices = apiServices;
        _connectivity = connectivity;
    }


    [RelayCommand]
    async Task LoginAsync()
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
            var result = await _apiServices.LoginUser(Login);
            if (result)
            {
                // Go to main page
                await Shell.Current.GoToAsync(nameof(MainPage));
            }
            else
            {
                await Shell.Current.DisplayAlert("Alert", "Something went wrong!", "Ok");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Alert", "Something went wrong!", "Ok");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task BackToRegisterPageAsync()
    {
        await Shell.Current.GoToAsync("..", true);
    }
}
