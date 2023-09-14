using ApplicationCMCM.MVVM.Models;
using ApplicationCMCM.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace ApplicationCMCM.MVVM.ViewModels;

[QueryProperty("Category", "Category")]
public partial class RequestPageViewModel : BaseViewModel
{
    private readonly ApiServices _apiServices;

    [ObservableProperty]
    private CategoryModel category;

    [ObservableProperty]
    private int categoryId;

    public RequestPageViewModel(ApiServices apiServices)
    {
        
        Title = "New Request";
        _apiServices = apiServices;
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
                var stream = await result.OpenReadAsync();
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
}
