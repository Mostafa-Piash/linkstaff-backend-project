using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;

namespace SocialNetwork.API.Extensions
{
    public static class HttpContextExtention
    {
        public static async Task<long> GetUserIdFromTokenAsync(this HttpContext httpContext)
        {
            var token = await httpContext.GetTokenAsync("access_token");
            var jwtToken = new JwtSecurityToken(token);
            return Convert.ToInt64(jwtToken.Subject);
        }
    }
}
