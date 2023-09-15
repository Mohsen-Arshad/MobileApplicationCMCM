using ApplicationCMCM.MVVM.Models;
using ApplicationCMCM.MVVM.Views;
using ApplicationCMCM.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mopups.Interfaces;
using Mopups.Services;
using System.Diagnostics;

namespace ApplicationCMCM.MVVM.ViewModels;

[QueryProperty("Category", "Category")]
public partial class RequestPageViewModel : BaseViewModel
{
    private readonly ApiServices _apiServices;
    private readonly IPopupNavigation _ipopupNavigation;

    [ObservableProperty]
    private RequestModel sendRequestModel = new();

    [ObservableProperty]
    private CategoryModel category;

    public RequestPageViewModel(ApiServices apiServices , IPopupNavigation ipopupNavigation)
    {
        
        Title = "New Request";
        _apiServices = apiServices;
        _ipopupNavigation = ipopupNavigation;
    }

    [RelayCommand]
    async Task CreateNewRequest(int categoryId)
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = true;
            SendRequestModel.CategoryId = categoryId;
            var result = await _apiServices.CreateRequest(SendRequestModel);

            if (result)
            {
                await Shell.Current.DisplayAlert("Created", $"Your request submitted", "Ok");
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", $"Unable to create user", "Ok");
            }
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
    async Task PickDocumnet()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = true;


            var fileTypes = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                { DevicePlatform.iOS, new[] { "public.image", "com.adobe.pdf" } },
                { DevicePlatform.Android, new[] { "image/*", "application/pdf" } },
                { DevicePlatform.WinUI, new[] { ".png", ".jpg", ".jpeg", ".pdf" } },
                { DevicePlatform.macOS, new[] { "public.image", "com.adobe.pdf" } }
                });

            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Pick The Document Please",
                FileTypes = fileTypes,
            });

            if (result != null)
            {
                var docFile = await result.OpenReadAsync();
                SendRequestModel.FileData = docFile;
                SendRequestModel.ContentType = result.ContentType;
                SendRequestModel.FileName = result.FileName;
                return;
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
    async Task BackToSelectCategories()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            await Shell.Current.GoToAsync("..");
            IsBusy = true;
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
    async Task PopupSelectDocument()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = true;

            await _ipopupNavigation.PushAsync(new PopupPage());
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
