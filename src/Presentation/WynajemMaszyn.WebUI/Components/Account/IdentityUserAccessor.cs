using Microsoft.AspNetCore.Identity;
using WynajemMaszyn.Application.Persistance.Auth;
using WynajemMaszyn.Domain.Entities;


namespace WynajemMaszyn.WebUI.Components.Account
{
    internal sealed class IdentityUserAccessor(IUserManagerService userManager, IdentityRedirectManager redirectManager)
    {

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
