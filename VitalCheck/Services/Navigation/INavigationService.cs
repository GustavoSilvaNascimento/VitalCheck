public interface INavigationService
{
    Task InitializeAsync();

    Task NavigationAsync(string route);

    Task NavigationAsync(string route,
        IDictionary<string, object> parameters);
}