using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCMCM.MVVM.ViewModels;

public partial class PopupPageViewModel : BaseViewModel
{
    public PopupPageViewModel()
    {
        
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
