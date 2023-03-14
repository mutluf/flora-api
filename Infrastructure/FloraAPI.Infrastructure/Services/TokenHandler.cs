using FloraAPI.Application.Abstractions;
using FloraAPI.Application.DTOs;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.IdentityModel.Tokens; //install nuget çünkü çalışmadı
using System.IdentityModel.Tokens.Jwt;

namespace FloraAPI.Infrastructure.Services
{
    public class TokenHandler : ITokenHandler
    {
        IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateToken(int minute)
        {
            Token token = new Token();
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);
            token.Expiration = DateTime.Now.AddMinutes(minute);

            JwtSecurityToken securityToken = new(
               audience: _configuration["Token:Audience"],
               issuer: _configuration["Token:Issuer"],
               expires: token.Expiration,
               notBefore: DateTime.Now,
               signingCredentials: signingCredentials
               );

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
