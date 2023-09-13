using ApplicationCMCM.MVVM.Models;
using ApplicationCMCM.Services;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ApplicationCMCM.MVVM.ViewModels;

public partial class UserRequestsPageViewModel : BaseViewModel
{
    private readonly ApiServices _apiServices;
    public ObservableCollection<RequestModel> UserRequests { get; } = new();

    public UserRequestsPageViewModel(ApiServices apiServices)
    {
        Title = "Requests History";
        _apiServices = apiServices;
        GetAllRequestsCommand.Execute(this);
    }

    [RelayCommand]
    async Task GetAllRequests()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = true;

            var uRequests = await _apiServices.GetAllRequests();

            if (UserRequests.Count != 0)
            {
                UserRequests.Clear();
            }

            foreach (var request in uRequests)
            {
                UserRequests.Add(request);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", "Something went wrong", "Ok");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
