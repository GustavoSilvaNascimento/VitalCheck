using System;
using System.Collections.Generic;
using System.Text;

namespace VitalCheck.Services.Security
{
    public interface ISecurityServices
    {
        Task<bool> IsAuthenticated(string senha, string hash);
        Task<string> GenerateHash(string senha);
        Task<string> GenerateToken();
    }
}
