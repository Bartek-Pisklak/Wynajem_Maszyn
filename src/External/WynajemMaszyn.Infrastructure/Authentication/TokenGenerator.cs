using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using WynajemMaszyn.Application.Common.Interfaces.Authentication;
using System.Net.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Configuration;
using Microsoft.Extensions.Options;

namespace WynajemMaszyn.Infrastructure.Authentication
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly JwtSettings _jwtSettings;

        public TokenGenerator(IOptions<JwtSettings> jwtOptions,IHttpContextAccessor contextAccessor)
        {
            _jwtSettings = jwtOptions.Value;
            _httpContextAccessor = contextAccessor;
        }


        public string GenerateToken(int userId, string firstName, string lastName, string permission)
        {
            var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim(ClaimTypes.Name, $"{firstName} {lastName}"),
                    new Claim(ClaimTypes.Role, permission),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // Unikalny identyfikator tokena
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(_jwtSettings.ExpiryMinutes);

            var tokenTemp = new JwtSecurityToken( 
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            string token = new JwtSecurityTokenHandler().WriteToken(tokenTemp);


            return token ;
        }
    }
}
