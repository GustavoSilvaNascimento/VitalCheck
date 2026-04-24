using VitalCheck.Model.Response;

namespace VitalCheck.Services.Users
{
    public interface IUserService
    {
  
        Task<Usuario> AddDb(Usuario user);
        Task InsertAsync(Usuario user);
        Task<Usuario?> GetByIdAsync(int id);
        Task<Usuario?> GetByEmailAndSenhaAsync(string email, string senha);
        Task<Usuario?> GetByEmailAsync(string email);
        Task<List<Usuario>> GetAllAsync();
        Task UpdateAsync(Usuario user);
        Task DeleteAsync(Usuario user);
        Task<Usuario?> GetByTokenAsync(string token);
    }
}
