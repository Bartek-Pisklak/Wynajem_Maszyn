using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;
using WynajemMaszyn.Application.Contracts.Authentication;
using WynajemMaszyn.Application.Persistance.Auth;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Infrastructure.Authentication
{
    public class SignInManagerService : ISignInManagerService
    {
        private readonly SignInManager<User> _signInManager;
        public IUserManagerService UserManager { get;  set; }

        public SignInManagerService(SignInManager<User> signInManager, IUserManagerService userManagerService) 
        {
            _signInManager = signInManager;
            UserManager = userManagerService;
        }

        public IdentityOptions Options { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public AuthenticationProperties ConfigureExternalAuthenticationProperties(string? provider, [StringSyntax("Uri")] string? redirectUrl, string? userId = null)
        {
            var result = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl, userId);
            return result;
        }

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

        public async Task<UserRegister?> GetTwoFactorAuthenticationUserAsync()
        {
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();

            UserRegister userRegister = new UserRegister
            {
                Id = user.Id,
                UserName = user.UserName,
                NormalizedUserName = user.NormalizedUserName,
                Email = user.Email,
                NormalizedEmail = user.NormalizedEmail,
                EmailConfirmed = user.EmailConfirmed,
                PasswordHash = user.PasswordHash,
                SecurityStamp = user.SecurityStamp,
                ConcurrencyStamp = user.ConcurrencyStamp,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                TwoFactorEnabled = user.TwoFactorEnabled,
                LockoutEnd = user.LockoutEnd,
                LockoutEnabled = user.LockoutEnabled,
                AccessFailedCount = user.AccessFailedCount,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            return userRegister;
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

        public async Task RefreshSignInAsync(UserRegister userRegister)
        {

            User user = new User
            {
                Id = userRegister.Id,
                UserName = userRegister.UserName,
                NormalizedUserName = userRegister.NormalizedUserName,
                Email = userRegister.Email,
                NormalizedEmail = userRegister.NormalizedEmail,
                EmailConfirmed = userRegister.EmailConfirmed,
                PasswordHash = userRegister.PasswordHash,
                SecurityStamp = userRegister.SecurityStamp,
                ConcurrencyStamp = userRegister.ConcurrencyStamp,
                PhoneNumber = userRegister.PhoneNumber,
                PhoneNumberConfirmed = userRegister.PhoneNumberConfirmed,
                TwoFactorEnabled = userRegister.TwoFactorEnabled,
                LockoutEnd = userRegister.LockoutEnd,
                LockoutEnabled = userRegister.LockoutEnabled,
                AccessFailedCount = userRegister.AccessFailedCount,
                FirstName = userRegister.FirstName,
                LastName = userRegister.LastName
            };

            await _signInManager.RefreshSignInAsync(user);
        }

        public async Task SignInAsync(User user, bool isPersistent, string? authenticationMethod = null)
        {
            await _signInManager.SignInAsync(user, isPersistent, authenticationMethod);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
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
