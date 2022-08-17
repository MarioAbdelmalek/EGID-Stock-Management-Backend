using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement
{
    public interface IJwtAuthenticationManager
    {
        AuthResDto Authenticate(string username, string password);
    }
}
