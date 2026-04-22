
using System;
using System.Collections.Generic;
using System.Text;
using VitalCheck.Model.Response;

namespace VitalCheck.Services.Users
{
    public interface IUserService
    {
  
        Task<Usuario> AddDb(Usuario user);
        Task<UserToken> AuthenticateDb(UserAuth auth, Usuario user);

    }
}
