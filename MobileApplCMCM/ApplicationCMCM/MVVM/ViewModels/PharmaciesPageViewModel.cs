using ApplicationCMCM.MVVM.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ApplicationCMCM.MVVM.ViewModels;

public partial class PharmaciesPageViewModel : BaseViewModel
{
    IGeolocation _geolocation;

    public ObservableCollection<PharmacyModel> PharmacyInfo { get; } = new();

    public PharmaciesPageViewModel(IGeolocation geolocation)
    {
        Title = "Pharmacies";
        _geolocation = geolocation;

        PharmacyInfo.Add((new PharmacyModel
        {
            PharmacyAddress = "25 Rue de la Gare",
            PharmacyName = "Pharmacie de la Gare",
            PharmacyPhoneNumber = "+352 5613 9513",
            Latitude = 49.6116,
            Longitude = 6.1319,
        }));

        PharmacyInfo.Add((new PharmacyModel
        {
            PharmacyAddress = "12 Avenue de la Liberté",
            PharmacyName = "Pharmacie Centrale",
            PharmacyPhoneNumber = "+352 8164 9334",
            Latitude = 49.6177,
            Longitude = 6.1373,
        }));

        PharmacyInfo.Add((new PharmacyModel
        {
            PharmacyAddress = "8 Rue des Capucins",
            PharmacyName = "Pharmacie de l'Europe",
            PharmacyPhoneNumber = "+352 2531 1584",
            Latitude = 49.6112,
            Longitude= 6.1259,
        }));

        PharmacyInfo.Add((new PharmacyModel
        {
            PharmacyAddress = "8 Rue des Capucins",
            PharmacyName = "Pharmacie du Boulevard",
            PharmacyPhoneNumber = "+352 9416 6634",
            Latitude = 49.6268,
            Longitude = 6.1427,
        }));
    }

    [RelayCommand]
    async Task BackToMainMenu()
    {
        await Shell.Current.GoToAsync("..");
    }
}
