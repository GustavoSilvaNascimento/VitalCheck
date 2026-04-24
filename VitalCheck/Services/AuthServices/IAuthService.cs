using VitalCheck.Model.Response;

public interface IAuthService
{
    Task<UserToken?> LoginAsync(string email, string senha);
    Task<UserToken?> RegisterAsync(Usuario usuario);
    Task LogoutAsync();
    Task<bool> IsLoggedAsync();
    Task<string?> GetTokenAsync();
    Task<Usuario?> GetCurrentUserAsync();
}