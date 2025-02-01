using WynajemMaszyn.Application.Contracts.Authentication;
using WynajemMaszyn.Application.Persistance.Auth;



namespace WynajemMaszyn.WebUI.Components.Account
{
    internal sealed class IdentityUserAccessor(IUserManagerService userManager, IdentityRedirectManager redirectManager)
    {

        public async Task<UserRegister> GetRequiredUserAsync(HttpContext context)
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
