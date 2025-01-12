using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Infrastructure.Persistance.Repositories
{
    public class UserContextGetIdService : IUserContextGetIdService
    {
        //private readonly HttpContext _httpContext;
        //private readonly UserManager<User> _userManager;

        public UserContextGetIdService()//UserManager<User> userManager, HttpContext httpContext)
        {
            //_httpContext = httpContext;
            //_userManager = userManager;
        }




        private readonly SignInManager<User> _signInManager;

        string? IUserContextGetIdService.GetUserId => "1";

        public ClaimsPrincipal User => throw new NotImplementedException();


        /*
public string? GetPermissionId => User is null
? null
: User.FindFirst(c => c.Type == ClaimTypes.Authentication)?.Value;*/

/*        string? GetUserId()
        {
            *//*            var a = _userManager.GetUserAsync(_httpContext);
                        var user = await _userManager.GetUserAsync(httpContext);

                            await UserAccessor.GetRequiredUserAsync(HttpContext)
                        var userId = await _userManager.FindByIdAsync()
                        return "1";*//*
            return "1";
        }*/
/*        public int? GetUserId => User is null ? null : 
            (int?)int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);*/
    }
}

