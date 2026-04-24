using VitalCheck.Services.Settings;

namespace VitalCheck.Services.Navigation;

public class NavigationService : INavigationService
{
    private readonly ISettingsService _settingsService;

    public NavigationService(ISettingsService settingsService)
    {
        _settingsService = settingsService;
    }

    public async Task InitializeAsync()
    {
        var token = await _settingsService.GetTokenAsync();

        if (string.IsNullOrWhiteSpace(token))
            await NavigationAsync("///Main");
        else
            await NavigationAsync("///Dashboard");
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