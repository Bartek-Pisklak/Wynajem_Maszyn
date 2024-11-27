using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using WynajemMaszyn.Application.Common.Interfaces.Authentication;
using System.Net.Http;

namespace WynajemMaszyn.Infrastructure.Authentication
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenGenerator(IHttpContextAccessor contextAccessor)
        {
            _httpContextAccessor = contextAccessor;
        }


        public async void GenerateToken(int userId, string firstName, string lastName, string permission)
        {
/*            var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Name, $"{firstName} {lastName}"),
            new Claim(ClaimTypes.Actor, permission)
        };
            var indentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(indentity);
            object value = await HttpContext!.SignInAsync(principal);*/
        }
    }
}
