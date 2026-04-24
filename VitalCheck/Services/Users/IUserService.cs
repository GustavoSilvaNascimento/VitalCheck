using VitalCheck.Model.Response;

namespace VitalCheck.Services.Users
{
    public interface IUserService
    {
  
        Task<Usuario> AddDb(Usuario user);
        Task<UserToken> AuthenticateDb(UserAuth auth, Usuario user);
        Task<UserToken> CreateToken(Usuario user);
        Task<Usuario> GetByEmailAndSenhaAsync(string email, string senha);
        Task<Usuario> GetByEmailAsync(string email);
        public string GetSettings();
        public void SetSettings(string token);
        Task<Usuario> GetByIdAsync(int id);
        Task<Usuario> GetByTokenAsync(string token);
        Task UpdateTokenAsync(Usuario usuario, string token);
    }
}
