using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using WynajemMaszyn.Application.Contracts.Authentication;
using WynajemMaszyn.Domain.Entities;


namespace WynajemMaszyn.Application.Persistance.Auth
{
    public interface ISignInManagerService
    {
        public IdentityOptions Options { get; set; }


        Task SignInAsync(User user, bool isPersistent, string? authenticationMethod = null);
        Task<SignInResult> TwoFactorRecoveryCodeSignInAsync(string recoveryCode);
        Task<ExternalLoginInfo?> GetExternalLoginInfoAsync(string? expectedXsrf = null);

        Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent);
        Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent, bool bypassTwoFactor);
        Task RefreshSignInAsync(UserRegister user);
        Task<SignInResult> PasswordSignInAsync(User user, string password, bool isPersistent, bool lockoutOnFailure);
        Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
        Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();
        Task<UserRegister?> GetTwoFactorAuthenticationUserAsync();
        Task ForgetTwoFactorClientAsync();
        Task SignOutAsync();
        IUserManagerService UserManager { get; set; }
        Task<SignInResult> TwoFactorAuthenticatorSignInAsync(string code, bool isPersistent, bool rememberClient);
        Task<bool> IsTwoFactorClientRememberedAsync(User user);
        AuthenticationProperties ConfigureExternalAuthenticationProperties(string? provider, [StringSyntax("Uri")] string? redirectUrl, string? userId = null);
    }
}
