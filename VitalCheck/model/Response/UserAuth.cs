using System;
using System.Collections.Generic;
using System.Text;

namespace VitalCheck.model.Response
{
    public class UserAuth
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public int ExpiresInMins { get; set; }
    }
}
