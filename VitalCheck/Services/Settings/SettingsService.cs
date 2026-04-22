using System;
using System.Collections.Generic;
using System.Text;

namespace VitalCheck.Services.Settings
{
    public class SettingsService : ISettingsService
    {
        private const string AccessToken = "acess_token";
        private readonly string _defaultToken = string.Empty;
        public string AuthAccessToken 
        { 
            get => Preferences.Get(AccessToken, _defaultToken);
            set => Preferences.Set(AccessToken, value);
        }

        public void ClearToken()
        {
            AuthAccessToken = _defaultToken;
        }
    }
}
