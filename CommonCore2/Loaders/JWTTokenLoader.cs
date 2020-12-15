using CommonCore.Interfaces.Loaders;
using CommonCore.Models.Authentication;
using CommonCore.Models.Responses;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore2.Loaders
{
    public class JWTTokenLoader : IAuthorizationTokenLoader
    {
        private readonly IConfiguration _configuration;

        public JWTTokenLoader(
            IConfiguration configuration
            )
        {
            _configuration = configuration;
        }

        public async Task<IResponse<string>> GetToken(PasswordRecord record)
        {
            var result = new MethodResponse<string>();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              record.Claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            result.Data = new JwtSecurityTokenHandler().WriteToken(token);

            return result;
        }
    }
}
