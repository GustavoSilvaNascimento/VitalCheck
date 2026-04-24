using VitalCheck.Model.Response;
using VitalCheck.Services.Security;
using VitalCheck.Services.Settings;
using VitalCheck.Services.Users;

namespace VitalCheck.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly ISecurityServices _security;
    private readonly ISettingsService _settings;

    public AuthService(
        IUserService userService,
        ISecurityServices security,
        ISettingsService settings)
    {
        _userService = userService;
        _security = security;
        _settings = settings;
    }

    public async Task<UserToken?> LoginAsync(
        string email,
        string senha)
    {
        var user = await _userService
            .GetByEmailAndSenhaAsync(email, senha);

        if (user == null)
            return null;

        return await CriarSessaoAsync(user);
    }

    public async Task<UserToken?> RegisterAsync(
        Usuario usuario)
    {
        var existente =
            await _userService
            .GetByEmailAsync(usuario.Email);

        if (existente != null)
            return null;

        var novo =
            await _userService.AddDb(usuario);

        return await CriarSessaoAsync(novo);
    }

    public async Task LogoutAsync()
    {
        await _settings.ClearTokenAsync();
    }

    public async Task<bool> IsLoggedAsync()
    {
        return await _settings.IsLoggedAsync();
    }

    public async Task<string?> GetTokenAsync()
    {
        return await _settings.GetTokenAsync();
    }

    public async Task<Usuario?> GetCurrentUserAsync()
    {
        var userId =
            await _settings.GetUserIdAsync();

        if (userId == null)
            return null;

        return await _userService
            .GetByIdAsync(userId.Value);
    }

    private async Task<UserToken> CriarSessaoAsync(
        Usuario user)
    {
        string token =
            await _security.GenerateToken();

        await _settings.SaveTokenAsync(token);
        await _settings.SaveUserIdAsync(user.Id);

        return new UserToken
        {
            Token = token,
            UserId = user.Id,
            Nome = user.Nome,
            Email = user.Email,
            Peso = user.Peso,
            Genero = user.Genero
        };
    }
}