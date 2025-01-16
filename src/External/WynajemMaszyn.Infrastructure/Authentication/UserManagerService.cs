using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;
using WynajemMaszyn.Application.Persistance.Auth;
using WynajemMaszyn.Domain.Entities;


public class UserManagerService : IUserManagerService
{
    private readonly UserManager<User> _userManager;
    private readonly IUserStore<User> _userStore;

    public UserManagerService(UserManager<User> userManager, IUserStore<User> userStore)
    {
        _userManager = userManager;
        _userStore = userStore;
    }




    public async Task<IdentityResult> AddLoginAsync(User user, UserLoginInfo login)
    {
        var result = await _userManager.AddLoginAsync(user, login);
        return result;
    }

    public async Task<IdentityResult> AddPasswordAsync(User user, string password)
    {
        var result = await _userManager.AddPasswordAsync(user, password);
        return result;
    }

    public async Task<IdentityResult> ChangeEmailAsync(User user, string newEmail, string token)
    {
        var result = await _userManager.ChangeEmailAsync(user, newEmail, token);
        return result;
    }

    public async Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword)
    {
        var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        return result;
    }

    public async Task<IdentityResult> ConfirmEmailAsync(User user, string token)
    {
        var result = await _userManager.ConfirmEmailAsync(user, token);
        return result;
    }

    public async Task<int> CountRecoveryCodesAsync(User user)
    {
        var result = await _userManager.CountRecoveryCodesAsync(user);
        return result;
    }

    public async Task<IdentityResult> CreateAsync(User user, string password)
    {
        var result = await _userManager.CreateAsync(user, password);

        if(result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user,"Client");
        }
        return result;
    }

    public async Task<IdentityResult> CreateAsync(User user)
    {
        var result = await _userManager.CreateAsync(user);
        return result;
    }

    public async Task<User> FindByEmailAsync(string email)
    {
        var result = await _userManager.FindByEmailAsync(email);
        return result;
    }

    public async Task<User?> FindByIdAsync(string userId)
    {
        var result = await _userManager.FindByIdAsync(userId);
        return result;
    }

    public async Task<string> GenerateChangeEmailTokenAsync(User user, string newEmail)
    {
        var result = await GenerateChangeEmailTokenAsync(user, newEmail);
        return result;
    }

    public async Task<string> GenerateEmailConfirmationTokenAsync(User user)
    {
        var result = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        return result;
    }

    public async Task<IEnumerable<string>?> GenerateNewTwoFactorRecoveryCodesAsync(User user, int number)
    {
        var result = await _userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, number);
        return result;
        
    }

    public async Task<string> GeneratePasswordResetTokenAsync(User user)
    {
        var result = await _userManager.GeneratePasswordResetTokenAsync(user);
        return result;
    }

    public async Task<string?> GetAuthenticatorKeyAsync(User user)
    {
        var result = await _userManager.GetAuthenticatorKeyAsync(user);
        return result;
    }

    public async Task<string?> GetEmailAsync(User user)
    {
        var result = await _userManager.GetEmailAsync(user);
        return result;
    }

    public async Task<IList<UserLoginInfo>> GetLoginsAsync(User user)
    {
        var result = await _userManager.GetLoginsAsync(user);
        return result;
    }

    public async Task<string?> GetPhoneNumberAsync(User user)
    {
        var result = await _userManager.GetPhoneNumberAsync(user);
        return result;
    }

    public async Task<string> GetSecurityStampAsync(User user)
    {
        var result = await _userManager.GetSecurityStampAsync(user);
        return result;
    }

    public async Task<bool> GetTwoFactorEnabledAsync(User user)
    {
        var result = await _userManager.GetTwoFactorEnabledAsync(user);
        return result;
    }

    public async Task<User> GetUserAsync(ClaimsPrincipal principal)
    {
        var result = await _userManager.GetUserAsync(principal);
        return result;
    }

    public string? GetUserId(ClaimsPrincipal principal)
    {
        string result = _userManager.GetUserId(principal);
        return result;
    }

    public async Task<string> GetUserIdAsync(User user)
    {
        var result = await _userManager.GetUserIdAsync(user);
        return result;
    }

    public async Task<string?> GetUserNameAsync(User user)
    {
        var result = await _userManager.GetUserNameAsync(user);
        return result;
    }

    public async Task<bool> HasPasswordAsync(User user)
    {
        var result = await _userManager.HasPasswordAsync(user);
        return result;
    }

    public async Task<bool> IsEmailConfirmedAsync(User user)
    {
        var result = await _userManager.IsEmailConfirmedAsync(user);
        return result;
    }

    public async Task<IdentityResult> RemoveLoginAsync(User user, string loginProvider, string providerKey)
    {
        var result = await _userManager.RemoveLoginAsync(user, loginProvider, providerKey);
        return result;
    }

    public async Task<IdentityResult> ResetAuthenticatorKeyAsync(User user)
    {
        var result = await _userManager.ResetAuthenticatorKeyAsync(user);
        return result;
    }

    public async Task<IdentityResult> ResetPasswordAsync(User user, string token, string newPassword)
    {
        var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
        return result;
    }

    public async Task<IdentityResult> SetPhoneNumberAsync(User user, string? phoneNumber)
    {
        var result = await _userManager.SetPhoneNumberAsync(user, phoneNumber);
        return result;
    }

    public async Task<IdentityResult> SetTwoFactorEnabledAsync(User user, bool enabled)
    {
        var result = await _userManager.SetTwoFactorEnabledAsync(user, enabled);
        return result;
    }

    public async Task<IdentityResult> SetUserNameAsync(User user, string? userName)
    {
        var result = await _userManager.SetUserNameAsync(user, userName);
        return result;
    }

    public bool SupportsUserEmail()
    {
        var result = _userManager.SupportsUserEmail;
        return result;
    }

    public bool SupportsUserSecurityStamp()
    {
        return _userManager.SupportsUserSecurityStamp;
    }

    public bool UserManagerOptionsSignInRequireConfirmedAccount()
    {
        return _userManager.Options.SignIn.RequireConfirmedAccount;
    }

    public string UserManagerOptionsTokensAuthenticatorTokenProvider()
    {
        return _userManager.Options.Tokens.AuthenticatorTokenProvider;
    }

    public async Task<bool> VerifyTwoFactorTokenAsync(User user, string tokenProvider, string token)
    {
        var result = await _userManager.VerifyTwoFactorTokenAsync(user, tokenProvider, token);
        return result;
    }
}
