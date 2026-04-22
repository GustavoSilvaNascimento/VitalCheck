using VitalCheck.Data.Interfaces;
using VitalCheck.Data.SqLite;
using VitalCheck.Model;

namespace VitalCheck.Services
{
    public class UsuarioService : DataBaseService<Usuario>
    {
        public UsuarioService(SqLiteDataBase database) : base(database) { 
        } 

        public async Task<Usuario> GetByEmailAndSenhaAsync(string email, string senha)
        {
            var todosUsuarios = await GetAllAsync();

            return todosUsuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}