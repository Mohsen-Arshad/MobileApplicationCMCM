using ApplicationCMCM.MVVM.Models;
using ApplicationCMCM.MVVM.Views;
using ApplicationCMCM.Services;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace ApplicationCMCM.MVVM.ViewModels;

public partial class LoginPageViewModel : BaseViewModel
{
    private readonly ApiServices _apiServices;

    public LoginModel Login { set; get; } = new LoginModel();

    public LoginPageViewModel(ApiServices apiServices)
    {
        Title = "Login";
        _apiServices = apiServices;
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
