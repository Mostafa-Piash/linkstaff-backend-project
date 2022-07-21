using Microsoft.IdentityModel.Tokens;
using SocialNetwork.Domain.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SocialNetwork.Core.Helper
{
    public static class AuthHelper
    {
        public static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public static string GenerateJwtAsync(this JwtConfiguration jwtConfigurationOptions, string email,long id)
        {
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfigurationOptions.SecurityKey));
            List<Claim> claims = new();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddSeconds(jwtConfigurationOptions.AccessTokenTimeout),
                Issuer = jwtConfigurationOptions.Authority,
                Audience = jwtConfigurationOptions.Audience,
                IssuedAt = DateTime.UtcNow,
                SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(token);
        }

    }
}
