using DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {

        private readonly PostgreSqlContext context;
        private readonly IConfiguration configuration;

        public JwtAuthenticationManager (PostgreSqlContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public AuthResDto Authenticate(string username, string password)
        {
            if(!context.Users.Any(u => u.Username == username && u.Password == password))
            {
                return new AuthResDto() { Token = "", Message = "Invalid Username or Password", isValid = false };
            }

            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(configuration.GetSection("AppSettings:Token").Value);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, username)
                    }),
                    Expires = DateTime.Now.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenS = tokenHandler.WriteToken(token);
                return new AuthResDto() { Token = tokenS, Message = "You Have Logged in Successfully", isValid = true };
            }
        }
    }

    public class AuthResDto
    {
        public string Token { get; set; }
        public string Message { get; set; }
        public Boolean isValid { get; set; }
    }
}
