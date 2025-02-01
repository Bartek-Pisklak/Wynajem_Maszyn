
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WynajemMaszyn.Application.Contracts.Authentication;

namespace WynajemMaszyn.Application.Persistance.Auth
{
    public interface IUserManagerService
    {
        Task<string> GetUserIdAsync(UserRegister user);
        Task<string> GenerateEmailConfirmationTokenAsync(UserRegister user);
        Task<UserRegister> FindByEmailAsync(string email);
        Task<IdentityResult> ResetPasswordAsync(UserRegister userRegister, string token, string newPassword);
        Task<bool> IsEmailConfirmedAsync(UserRegister user);
        Task<string> GeneratePasswordResetTokenAsync(UserRegister user);
        Task<UserRegister?> FindByIdAsync(string userId);
        Task<IdentityResult> ChangeEmailAsync(UserRegister user, string newEmail, string token);
        Task<IdentityResult> SetUserNameAsync(UserRegister user, string? userName);
        bool SupportsUserEmail();
        Task<string?> GetUserNameAsync(UserRegister userRegister);
        Task<string?> GetPhoneNumberAsync(UserRegister userRegister);
        Task<bool> VerifyTwoFactorTokenAsync(UserRegister user, string tokenProvider, string token);
        Task<IdentityResult> SetPhoneNumberAsync(UserRegister userRegister, string? phoneNumber);
        Task<IEnumerable<string>?> GenerateNewTwoFactorRecoveryCodesAsync(UserRegister userRegister, int number);
        Task<string?> GetAuthenticatorKeyAsync(UserRegister user);
        Task<bool> GetTwoFactorEnabledAsync(UserRegister userRegister);
        Task<int> CountRecoveryCodesAsync(UserRegister user);
        Task<string> GenerateChangeEmailTokenAsync(UserRegister user, string newEmail);
        Task<IdentityResult> ChangePasswordAsync(UserRegister user, string currentPassword, string newPassword);
        Task<string?> GetEmailAsync(UserRegister user);
        Task<bool> HasPasswordAsync(UserRegister user);
        Task<IdentityResult> AddPasswordAsync(UserRegister userRegister, string password);
        Task<IdentityResult> ConfirmEmailAsync(UserRegister user, string token);
        Task<IdentityResult> SetTwoFactorEnabledAsync(UserRegister userRegister, bool enabled);
        Task<IdentityResult> ResetAuthenticatorKeyAsync(UserRegister userRegister);
        Task<UserRegister> GetUserAsync(ClaimsPrincipal principal);
        string? GetUserId(ClaimsPrincipal principal);


        Task<string> GetSecurityStampAsync(UserRegister user);
        bool SupportsUserSecurityStamp();
        bool UserManagerOptionsSignInRequireConfirmedAccount();
        string UserManagerOptionsTokensAuthenticatorTokenProvider();

    }
}
