using ApplicationCMCM.Services;
using CommunityToolkit.Mvvm.Input;

namespace ApplicationCMCM.MVVM.ViewModels;

public partial class UserPanelPageViewModel : BaseViewModel
{
    private readonly ApiServices _apiServices;

    public UserPanelPageViewModel(ApiServices apiServices)
	{
        _apiServices = apiServices;
        GetUserInfoCommand.Execute(this);
    }

    [RelayCommand]
    async Task GetUserInfo()
    {
        
    }
}
