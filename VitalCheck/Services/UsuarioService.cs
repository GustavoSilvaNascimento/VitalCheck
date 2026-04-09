using VitalCheck.Data.Interfaces;
using VitalCheck.Data.SqLite;
using VitalCheck.Model;

namespace VitalCheck.Services
{
    public class UsuarioService : DataBaseService<Usuario>
    {
        public UsuarioService(SqLiteDataBase database) : base(database) { 
        } 
    }
}