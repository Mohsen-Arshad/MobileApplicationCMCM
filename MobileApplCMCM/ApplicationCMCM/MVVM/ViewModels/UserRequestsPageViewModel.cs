using ApplicationCMCM.MVVM.Models;
using ApplicationCMCM.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ApplicationCMCM.MVVM.ViewModels;

public partial class UserRequestsPageViewModel : BaseViewModel
{
    private readonly ApiServices _apiServices;
    private readonly IConnectivity _connectivity;

    public ObservableCollection<RequestModel> UserRequests { get; } = new();

    public UserRequestsPageViewModel(ApiServices apiServices, IConnectivity connectivity)
    {
        Title = "Requests History";
        _apiServices = apiServices;
        _connectivity = connectivity;
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
            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {

                await Shell.Current.DisplayAlert("Internet Issue", $"Please check your internet connection and try again!", "Ok");
                return;
            }
            IsBusy = true;

            var uRequests = await _apiServices.GetAllRequests();

            if (UserRequests.Count != 0)
            {
                UserRequests.Clear();
            }

            foreach (var request in uRequests)
            {
                switch (request.CategoryId)
                {
                    case 1:
                        request.CategoryName = "Dental Care";
                        break;
                    case 2:
                        request.CategoryName = "Hospital";
                        break;
                    case 3:
                        request.CategoryName = "Optical";
                        break;
                    case 4:
                        request.CategoryName = "Orthopedics";
                        break;
                    case 5:
                        request.CategoryName = "Abroad";
                        break;
                    case 6:
                        request.CategoryName = "Miscellaneous";
                        break;
                    case 7:
                        request.CategoryName = "Certificate";
                        break;
                    case 8:
                        request.CategoryName = "Osteopathy";
                        break;
                    default:
                        break;
                }
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

    [RelayCommand]
    async Task BackToMainMenu()
    {
        await Shell.Current.GoToAsync("..");
    }
}
