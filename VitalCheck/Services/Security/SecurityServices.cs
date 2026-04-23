using System.Security.Cryptography;
using System.Text;

namespace VitalCheck.Services.Security
{
    public class SecurityServices : ISecurityServices
    {
        public Task<string> GenerateHash(string senha)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return Task.FromResult(builder.ToString());
            }
        }

        public Task<string> GenerateToken()
        {
            string token = RandomNumberGenerator.GetInt32(1, 999999).ToString("D6");
            string tokenHash = GenerateHash(token).Result;
            return Task.FromResult(tokenHash);
        }

        public Task<bool> IsAuthenticated(string senha, string hash)
        {
            if (senha == null || hash == null)
                return Task.FromResult(false);
            var senhaHash = GenerateHash(senha).Result;
            if (senhaHash == hash)
                return Task.FromResult(true);
            return Task.FromResult(false);
        }
    }
}
