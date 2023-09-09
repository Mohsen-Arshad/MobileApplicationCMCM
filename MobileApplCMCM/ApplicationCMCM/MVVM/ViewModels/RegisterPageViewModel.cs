using ApplicationCMCM.MVVM.Models;
using ApplicationCMCM.Services;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Windows.Input;

namespace ApplicationCMCM.MVVM.ViewModels;

public partial class RegisterPageViewModel : BaseViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string IdentificationNumber { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }

    private readonly ApiServices _apiServices;

    public RegisterModel Register { get; set; } = new RegisterModel();

    public RegisterPageViewModel(ApiServices apiServices)
    {
        Title = "Register CMCM";
        _apiServices = apiServices;
        
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
            IsBusy = true;
            var result = await _apiServices.RegisterUser(Register);
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
}
