using Microsoft.IdentityModel.Tokens;
using PlayersBook.Auth.Models;
using PlayersBook.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace PlayersBook.Auth.Services
{
    public static class TokenService
    {
        public static string GenerateToken(Player player)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, player.Name),
                    new Claim(ClaimTypes.Email, player.Email),
                    new Claim(ClaimTypes.NameIdentifier, player.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static string? GetValueFromClaim(IIdentity identity, string field)
        {
            ClaimsIdentity? claims = identity as ClaimsIdentity;
            return claims?.FindFirst(field)?.Value;
        }
    }
}
