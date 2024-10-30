using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using WynajemMaszyn.Application.Persistance;

namespace WynajemMaszyn.Infrastructure.Persistance.Repositories
{
    public class UserContextGetIdService : IUserContextGetIdService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextGetIdService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;

        public int? GetUserId => User is null ? null : (int?)int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

    }
}

