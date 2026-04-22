

using VitalCheck.model.Response;
using VitalCheck.Services.DataBase.Create;
using VitalCheck.Services.SecurityService;
using VitalCheck.Services.Users;

namespace VitalCheck.Services.Users
{
    public class UserService(ISecurity security) : DataBaseService, IUserService
    {

        private readonly ISecurity _security = security;

        #region Database
        public async Task<Usuario> AddDb(Usuario user)
        {
            await UserConection.AddAsync(user);
            return await UserConection.GetAsync(x => x.Id == user.Id);
        }
        public async Task<UserToken> AuthenticateDb(UserAuth auth, Usuario user)
        {
            bool isValid = await UserConection.GetAsync(x => x.Email == auth.UserName && x.Senha == auth.Password) != null;
            if (isValid)
            {
                var userToken = CreateToken(user).Result;
                return userToken;
            }
            return null;
        }
        #endregion
        public async Task<UserToken> CreateToken(Usuario user)
        {
            var userToken = new UserToken { Token = _security.GenerateToken().Result };
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
