using ApplicationCMCM.MVVM.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ApplicationCMCM.MVVM.ViewModels;

[QueryProperty("Category", "Category")]
public partial class RequestPageViewModel : BaseViewModel
{
    [ObservableProperty]
    CategoryModel category;
    public RequestPageViewModel()
    {
        
    }
}
