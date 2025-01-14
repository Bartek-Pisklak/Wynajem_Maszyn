using Microsoft.AspNetCore.Identity;
using WynajemMaszyn.Application.Persistance.Auth;
using WynajemMaszyn.Domain.Entities;


namespace WynajemMaszyn.WebUI_Auth.Components.Account
{
    internal sealed class IdentityUserAccessor(IUserManagerService userManager, IdentityRedirectManager redirectManager)
    {
        UserManager<User> UserManager { get; set; }
        SignInManager<User> SignInManager { get; set; }
        public async Task<User> GetRequiredUserAsync(HttpContext context)
        {
            var user = await userManager.GetUserAsync(context.User);

            if (user is null)
            {
                redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
            }

            return user;
        }
    }
}
