using System;
using System.Collections.Generic;
using System.Text;

namespace VitalCheck.Services.SecurityService
{
    public interface ISecurity
    {
        Task<bool> IsAuthenticated(string senha, string hash);
        Task<string> GenerateHash(string senha);
        Task<string> GenerateToken();
    }
}
