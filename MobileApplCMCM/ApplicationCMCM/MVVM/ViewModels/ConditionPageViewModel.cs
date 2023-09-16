using ApplicationCMCM.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCMCM.MVVM.ViewModels;

public class ConditionPageViewModel
{
    public ConditionPageViewModel()
    {
        CheckUserLoginDetails();
    }

    private async void CheckUserLoginDetails()
    {
        string userDetails = await SecureStorage.GetAsync("AccessToken");

        if (string.IsNullOrWhiteSpace(userDetails))
        {
            await Shell.Current.GoToAsync(nameof(RegisterPage));
        }
        else
        {

            await Shell.Current.GoToAsync(nameof(MainPage));
        }
    }
}
