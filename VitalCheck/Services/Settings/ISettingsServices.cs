using System;
using System.Collections.Generic;
using System.Text;

namespace VitalCheck.Services.Settings
{
    public interface ISettingsService
    {
        string AuthAccessToken { get; set; }

        void ClearToken();
    }
}
