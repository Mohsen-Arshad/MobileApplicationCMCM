using ApplicationCMCM.MVVM.ViewModels;
using ApplicationCMCM.MVVM.Views;
using ApplicationCMCM.Services;
using Microsoft.Extensions.Logging;
using Mopups.Hosting;
using Mopups.Interfaces;
using Mopups.Services;

namespace ApplicationCMCM
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureMopups()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
            builder.Services.AddSingleton<IMap>(Map.Default);
            builder.Services.AddSingleton<IPhoneDialer>(PhoneDialer.Current);

            builder.Services.AddSingleton<ApiServices>();
            builder.Services.AddSingleton<IPopupNavigation>(MopupService.Instance);

            // Views
            builder.Services.AddSingleton<RegisterPage>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<UserRequestsPage>();
            builder.Services.AddTransient<PharmaciesPage>();
            builder.Services.AddTransient<UserPanelPage>();
            builder.Services.AddSingleton<CategoriesPage>();
            builder.Services.AddTransient<RequestPage>();
            builder.Services.AddSingleton<ConditionPage>();

            // ViewModels
            builder.Services.AddSingleton<RegisterPageViewModel>();
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<UserRequestsPageViewModel>();
            builder.Services.AddTransient<PharmaciesPageViewModel>();
            builder.Services.AddTransient<UserPanelPageViewModel>();
            builder.Services.AddSingleton<CategoriesPageViewModel>();
            builder.Services.AddTransient<RequestPageViewModel>();
            builder.Services.AddSingleton<ConditionPageViewModel>();


            return builder.Build();
        }
    }
}