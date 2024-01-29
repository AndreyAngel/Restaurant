using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Restaurant.Auth.Core.Helpers
{
    public class JwtTokenHelper
    {
        public static string GenerateTokenForUser(IConfiguration configuration, List<Claim> claims)
        {
            return GenerateJwtToken(configuration, claims, DateTime.MaxValue);
        }

        public static string ValidateToken(IConfiguration configuration, string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(configuration["Authentication:Secret"]);

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = false,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            }, out SecurityToken validatedToken);

            return tokenHandler.WriteToken((JwtSecurityToken)validatedToken);
        }

        private static string GenerateJwtToken(IConfiguration configuration, List<Claim> claims, DateTime expirationTime)
        {
            var key = Encoding.UTF8.GetBytes(configuration["Authentication:Secret"]);

            var token = new JwtSecurityToken(
                null,
                null,
                claims,
                DateTime.UtcNow,
                expirationTime,
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
