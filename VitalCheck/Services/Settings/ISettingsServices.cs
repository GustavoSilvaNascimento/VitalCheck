using System.Threading.Tasks;

namespace VitalCheck.Services.Settings;

public interface ISettingsService
{
    Task<string?> GetTokenAsync();
    Task SaveTokenAsync(string token);
    Task<bool> IsLoggedAsync();
    Task ClearTokenAsync();
    Task SaveUserIdAsync(int userId);
    Task<int?> GetUserIdAsync();
}