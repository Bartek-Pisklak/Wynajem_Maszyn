using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Persistance.Auth
{
    public interface IUserManagerService
    {

        Task<IdentityResult> CreateAsync(User user);
        Task<IdentityResult> CreateAsync(User user, string password);
        Task<IdentityResult> AddLoginAsync(User user, UserLoginInfo login);
        Task<string> GetUserIdAsync(User user);
        Task<string> GenerateEmailConfirmationTokenAsync(User user);
        Task<User> FindByEmailAsync(string email);
        Task<IdentityResult> ResetPasswordAsync(User user, string token, string newPassword);
        Task<bool> IsEmailConfirmedAsync(User user);
        Task<string> GeneratePasswordResetTokenAsync(User user);
        Task<User?> FindByIdAsync(string userId);
        Task<IdentityResult> ChangeEmailAsync(User user, string newEmail, string token);
        Task<IdentityResult> SetUserNameAsync(User user, string? userName);
        bool SupportsUserEmail();
        Task<string?> GetUserNameAsync(User user);
        Task<string?> GetPhoneNumberAsync(User user);
        Task<IList<UserLoginInfo>> GetLoginsAsync(User user);
        Task<IdentityResult> RemoveLoginAsync(User user, string loginProvider, string providerKey);
        Task<bool> VerifyTwoFactorTokenAsync(User user, string tokenProvider, string token);
        Task<IdentityResult> SetPhoneNumberAsync(User user, string? phoneNumber);
        Task<IEnumerable<string>?> GenerateNewTwoFactorRecoveryCodesAsync(User user, int number);
        Task<string?> GetAuthenticatorKeyAsync(User user);
        Task<bool> GetTwoFactorEnabledAsync(User user);
        Task<int> CountRecoveryCodesAsync(User user);
        Task<string> GenerateChangeEmailTokenAsync(User user, string newEmail);
        Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword);
        Task<string?> GetEmailAsync(User user);
        Task<bool> HasPasswordAsync(User user);
        Task<IdentityResult> AddPasswordAsync(User user, string password);
        Task<IdentityResult> ConfirmEmailAsync(User user, string token);
        Task<IdentityResult> SetTwoFactorEnabledAsync(User user, bool enabled);
        Task<IdentityResult> ResetAuthenticatorKeyAsync(User user);
        Task<User> GetUserAsync(ClaimsPrincipal principal);
        string? GetUserId(ClaimsPrincipal principal);


        Task<string> GetSecurityStampAsync(User user);
        bool SupportsUserSecurityStamp();
        bool UserManagerOptionsSignInRequireConfirmedAccount();
        string UserManagerOptionsTokensAuthenticatorTokenProvider();

    }
}
