using VitalCheck.Services.Settings;

namespace VitalCheck.Services.Navigation
{
    public class NavigationService(ISettingsService settingsService) : INavigationService
    {
        
        private readonly ISettingsService _settingsService = settingsService;

        public Task InitializeAsync()
        {
            var defaultRoute = "Dashboard";
            if (string.IsNullOrEmpty(_settingsService.AuthAccessToken))
                defaultRoute= "Login";
            return NavigationAsync(defaultRoute);
        }
        public Task NavigationAsync(string route) { 
            return Shell.Current.GoToAsync(route);

        }
        public Task NavigationAsync(string route, object parameter)
        {
            return Shell.Current.GoToAsync(route, (ShellNavigationQueryParameters)parameter);
        }
    }   
}
