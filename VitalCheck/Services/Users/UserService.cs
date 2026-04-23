

using VitalCheck.Model.Response;
using VitalCheck.Services.DataBase.Create;
using VitalCheck.Services.Security;
using VitalCheck.Services.Users;

namespace VitalCheck.Services.Users
{
    public class UserService(ISecurityServices security) : DataBaseService, IUserService
    {

        private readonly ISecurityServices _security = security;

        #region Database
        public async Task<Usuario> AddDb(Usuario user)
        {
            await UserConection.AddAsync(user);
            return user;
        }
        public async Task<UserToken> AuthenticateDb(UserAuth auth, Usuario user)
        {
            
            var dbUser = await UserConection.GetAsync(x => x.Email == auth.UserName && x.Senha == auth.Password);
            if (dbUser != null)
                return await CreateToken(dbUser);
            return null;
        }
        #endregion
        public async Task<UserToken> CreateToken(Usuario user)
        {
            var userToken = new UserToken { Token = await _security.GenerateToken() };
            userToken.Id = user.Id;
            userToken.Nome = user.Nome;
            userToken.UserName = user.UserName;
            userToken.Email = user.Email;
            userToken.Senha = user.Senha;
            userToken.Genero = user.Genero;
            userToken.DataNascimento = user.DataNascimento;
            userToken.Peso = user.Peso;
            return await Task.FromResult(userToken);
        }
        public async Task<Usuario> GetByEmailAndSenhaAsync(string email, string senha)
        {
            return await UserConection.GetAsync(x => x.Email == email && x.Senha == senha);
        }
        public async Task InsertAsync(Usuario user)
        {
            await UserConection.AddAsync(user);

        }
    }
}
