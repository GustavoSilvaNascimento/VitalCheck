using VitalCheck.Services.Settings;

namespace VitalCheck.Services.Navigation;

public class NavigationService : INavigationService
{
    private readonly ISettingsService _settingsService;

    public NavigationService(ISettingsService settingsService)
    {
        _settingsService = settingsService;
    }

    public Task InitializeAsync()
    {
        if (string.IsNullOrEmpty(_settingsService.AuthAccessToken))
            return NavigationAsync("///Main");

        return NavigationAsync("///Dashboard");
    }

    public Task NavigationAsync(string route)
    {
        return Shell.Current.GoToAsync(route);
    }

    public Task NavigationAsync(string route, IDictionary<string, object> parameters)
    {
        return Shell.Current.GoToAsync(route, parameters);
    }
}