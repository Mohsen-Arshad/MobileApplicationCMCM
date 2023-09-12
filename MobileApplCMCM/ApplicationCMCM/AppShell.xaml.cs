using ApplicationCMCM.MVVM.Views;

namespace ApplicationCMCM
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(RequestPage), typeof(RequestPage));
            Routing.RegisterRoute(nameof(UserRequestsPage), typeof(UserRequestsPage));
            Routing.RegisterRoute(nameof(UserPanelPage), typeof(UserPanelPage));
            Routing.RegisterRoute(nameof(PharmaciesPage), typeof(PharmaciesPage));
            Routing.RegisterRoute(nameof(CategoriesPage), typeof(CategoriesPage));

        }
    }
}