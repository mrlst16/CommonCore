using CommonCore.Interfaces.Loaders;
using CommonCore.Models.Authentication;
using CommonCore.Models.Responses;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore2.Loaders
{
    public class JWTTokenLoader : IAuthorizationTokenLoader
    {
        private readonly string _key;
        private readonly string _issuer;

        public JWTTokenLoader(
            IConfiguration configuration
            )
        {
            _key = configuration.GetValue<string>("Jwt:Key");
            _issuer = configuration.GetValue<string>("Jwt:Issuer");
        }

        public async Task<IResponse<string>> GetToken(PasswordRecord record)
        {
            if (record.Claims == null)
                record.Claims = new List<Claim>();
            if (record.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name) == null)
                record.Claims.Add(new Claim(ClaimTypes.Name, record.UserName));

            var result = new MethodResponse<string>()
                            .AsSucces();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _issuer,
                _issuer,
                record.Claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
                );

            result.Data = new JwtSecurityTokenHandler().WriteToken(token);

            return result;
        }
    }
}
