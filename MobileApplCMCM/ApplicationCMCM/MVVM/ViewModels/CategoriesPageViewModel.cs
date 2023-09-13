using ApplicationCMCM.MVVM.Models;
using ApplicationCMCM.Services;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ApplicationCMCM.MVVM.ViewModels;

public partial class CategoriesPageViewModel : BaseViewModel
{

    public ObservableCollection<CategoryModel> Categories { get; } = new();

    private readonly ApiServices _apiServices;

    public CategoriesPageViewModel(ApiServices apiServices)
    {
        Title = "Categories";
        _apiServices = apiServices;
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
}
