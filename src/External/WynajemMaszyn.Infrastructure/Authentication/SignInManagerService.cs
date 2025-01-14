using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using WynajemMaszyn.Application.Persistance.Auth;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Infrastructure.Authentication
{
    public class SignInManagerService : ISignInManagerService
    {
        private readonly SignInManager<User> _signInManager;


        public SignInManagerService(SignInManager<User> signInManager) 
        {
            _signInManager = signInManager;
        }

        public IdentityOptions Options { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent)
        {
            var result = await _signInManager.ExternalLoginSignInAsync(loginProvider, providerKey, isPersistent);
            return result;
        }

        public async Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent, bool bypassTwoFactor)
        {
            var result = await _signInManager.ExternalLoginSignInAsync(loginProvider,providerKey,isPersistent,bypassTwoFactor);
            return result;
        }

        public Task ForgetTwoFactorClientAsync() => _signInManager.ForgetTwoFactorClientAsync();


        public async Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync()
        {
            var result = await _signInManager.GetExternalAuthenticationSchemesAsync();
            return result;
        }

        public async Task<ExternalLoginInfo?> GetExternalLoginInfoAsync(string? expectedXsrf = null)
        {
            var result = await _signInManager.GetExternalLoginInfoAsync(expectedXsrf);
            return result;
        }

        public async Task<User?> GetTwoFactorAuthenticationUserAsync()
        {
            var result = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            return result;
        }

        public async Task<bool> IsTwoFactorClientRememberedAsync(User user)
        {
            var result = await _signInManager.IsTwoFactorClientRememberedAsync(user);
            return result;
        }


        public async Task<SignInResult> PasswordSignInAsync(User user, string password, bool isPersistent, bool lockoutOnFailure)
        {
            var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);
            return result;
        }

        public async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
            return result;
        }

        public async Task RefreshSignInAsync(User user)
        {
            await _signInManager.RefreshSignInAsync(user);
        }

        public async Task SignInAsync(User user, bool isPersistent, string? authenticationMethod = null)
        {
            await _signInManager.SignInAsync(user, isPersistent, authenticationMethod);
        }


        public async Task<SignInResult> TwoFactorAuthenticatorSignInAsync(string code, bool isPersistent, bool rememberClient)
        {
            var result = await _signInManager.TwoFactorAuthenticatorSignInAsync(code, isPersistent, rememberClient);
            return result;
        }

        public async Task<SignInResult> TwoFactorRecoveryCodeSignInAsync(string recoveryCode)
        {
            var result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(recoveryCode);
            return result;
        }
    }
}
