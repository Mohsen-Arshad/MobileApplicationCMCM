using ApplicationCMCM.MVVM.ViewModels;
using ApplicationCMCM.MVVM.Views;
using ApplicationCMCM.Services;
using Microsoft.Extensions.Logging;

namespace ApplicationCMCM
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<ApiServices>();

            // Views
            builder.Services.AddSingleton<RegisterPage>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<UserRequestsPage>();
            builder.Services.AddSingleton<PharmaciesPage>();
            builder.Services.AddSingleton<UserPanelPage>();
            builder.Services.AddSingleton<CategoriesPage>();
            builder.Services.AddTransient<RequestPage>();

            // ViewModels
            builder.Services.AddSingleton<RegisterPageViewModel>();
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<UserRequestsPageViewModel>();
            builder.Services.AddSingleton<PharmaciesPageViewModel>();
            builder.Services.AddSingleton<UserPanelPageViewModel>();
            builder.Services.AddSingleton<CategoriesPageViewModel>();
            builder.Services.AddTransient<RequestPageViewModel>();


            return builder.Build();
        }
    }
}