using ApplicationCMCM.MVVM.Models;
using ApplicationCMCM.MVVM.Views;
using ApplicationCMCM.Services;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ApplicationCMCM.MVVM.ViewModels;

public partial class CategoriesPageViewModel : BaseViewModel
{

    public ObservableCollection<CategoryModel> Categories { get; } = new();

    private readonly ApiServices _apiServices;
    private readonly IConnectivity _connectivity;

    public CategoriesPageViewModel(ApiServices apiServices, IConnectivity connectivity)
    {
        Title = "Request Type";
        _apiServices = apiServices;
        _connectivity = connectivity;
        GetAllCategoriesCommand.Execute(this);
    }

    [RelayCommand]
    async Task GetAllCategories()
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
            var categoriesResult = await _apiServices.GetCategories();

            if (Categories.Count != 0)
            {
                Categories.Clear();
            }

            foreach (var category in categoriesResult)
            {
                Categories.Add(category);
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
    async Task GoToRequestPage(CategoryModel categoryModel)
    {
        if (categoryModel is null)
        {
            return;
        }

        await Shell.Current.GoToAsync($"{nameof(RequestPage)}", true,
            new Dictionary<string, object>
            {
                { "Category" , categoryModel }
            });
    }
}
