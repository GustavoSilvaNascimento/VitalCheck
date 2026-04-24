using VitalCheck.Model.Response;
using VitalCheck.Services.DataBase.Create;

namespace VitalCheck.Services.Users
{
    public class UserService : DataBaseService, IUserService
    {
        public async Task<Usuario> AddDb(Usuario user)
        {
            await UserConection.AddAsync(user);
            return user;
        }

        public async Task InsertAsync(Usuario user)
        {
            await UserConection.AddAsync(user);
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await UserConection.GetAsync(x => x.Id == id);
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await UserConection.GetAsync(x =>
                x.Email == email);
        }

        public async Task<Usuario?> GetByEmailAndSenhaAsync(
            string email,
            string senha)
        {
            return await UserConection.GetAsync(x =>
                x.Email == email &&
                x.Senha == senha);
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await UserConection.GetAllAsync();
        }

        public async Task UpdateAsync(Usuario user)
        {
            await UserConection.UpdateAsync(user);
        }

        public async Task DeleteAsync(Usuario user)
        {
            await UserConection.DeleteAsync(user);
        }
        
        public async Task<Usuario?> GetByTokenAsync(string token)
        {
            UserToken userToken = await UserTokenConnection.GetAsync(x => x.Token == token);
            if (userToken == null)
                return null;

            return await UserConection.GetAsync(x => x.Id == userToken.UserId);
        }
    }
}