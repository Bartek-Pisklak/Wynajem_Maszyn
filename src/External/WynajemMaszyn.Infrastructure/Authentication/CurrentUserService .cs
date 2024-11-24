using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using WynajemMaszyn.Application.Common.Interfaces.Authentication;

namespace WynajemMaszyn.Infrastructure.Authentication
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int? GetUserId
        {
            get
            {
                var user = _httpContextAccessor.HttpContext?.User;
                if (user?.Identity?.IsAuthenticated != true)
                {
                    return null;
                }

                var userIdClaim = user.FindFirst("UserId")?.Value;
                return int.TryParse(userIdClaim, out var userId) ? userId : null;
            }
        }

        // Zwraca jedną rolę użytkownika
        public string GetPermission =>
            _httpContextAccessor.HttpContext?.User?.FindFirst("Permission")?.Value ?? string.Empty;

    }
}
