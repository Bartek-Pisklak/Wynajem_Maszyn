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

        public int? GetUserId => int.Parse(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier));

        public ClaimsPrincipal User => throw new NotImplementedException();


        /*        public bool HasPermission(string permission)
                {
                    return _httpContextAccessor.HttpContext?.User?.Claims.Any(c => c.Type == "Permission" && c.Value == permission) ?? false;
                }*/
    }
}

