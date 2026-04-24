using Microsoft.Maui.Storage;

namespace VitalCheck.Services.Settings
{
    public class SettingsService : ISettingsService
    {
        private const string TokenKey = "access_token";
        private const string UserIdKey = "user_id";

        public async Task SaveTokenAsync(string token)
        {
            await SecureStorage.SetAsync(TokenKey, token);
        }

        public async Task<string?> GetTokenAsync()
        {
            return await SecureStorage.GetAsync(TokenKey);
        }

        public async Task SaveUserIdAsync(int userId)
        {
            await SecureStorage.SetAsync(UserIdKey, userId.ToString());
        }

        public async Task<int?> GetUserIdAsync()
        {
            var value = await SecureStorage.GetAsync(UserIdKey);

            if (int.TryParse(value, out int id))
                return id;

            return null;
        }

        public Task ClearTokenAsync()
        {
            SecureStorage.Remove(TokenKey);
            SecureStorage.Remove(UserIdKey);

            return Task.CompletedTask;
        }

        public async Task<bool> IsLoggedAsync()
        {
            var token = await GetTokenAsync();
            return !string.IsNullOrWhiteSpace(token);
        }
    }
}