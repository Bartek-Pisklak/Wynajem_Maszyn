
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using WynajemMaszyn.Application.Persistance.Auth;
using WynajemMaszyn.Domain.Entities;


public class UserService : IUserManagerService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<SignInResult> LoginAsync(string username, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(username, password, isPersistent: false, lockoutOnFailure: false);
        return result;
    }


    public Task<IdentityResult> CreateAsync(User user, string password)
    {
        /*        var result = await _signInManager.CreateUserPrincipalAsync(user);
                    //_signInManager.CreateAsync(user, password);

                return result;*/
        throw new NotImplementedException();
    }

    public Task<string> GenerateEmailConfirmationTokenAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetUserIdAsync(User user)
    {
        throw new NotImplementedException();
    }



}
