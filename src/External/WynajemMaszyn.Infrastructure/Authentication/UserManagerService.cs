using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;
using WynajemMaszyn.Application.Contracts.Authentication;
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

    public async Task<IdentityResult> AddPasswordAsync(UserRegister userRegister, string password)
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
        var result = await _userManager.AddPasswordAsync(user, password);
        return result;
    }

    public async Task<IdentityResult> ChangeEmailAsync(UserRegister userRegister, string newEmail, string token)
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
        var result = await _userManager.ChangeEmailAsync(user, newEmail, token);
        return result;
    }

    public async Task<IdentityResult> ChangePasswordAsync(UserRegister userRegister, string currentPassword, string newPassword)
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


        var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        return result;
    }

    public async Task<IdentityResult> ConfirmEmailAsync(UserRegister userRegister, string token)
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
        var result = await _userManager.ConfirmEmailAsync(user, token);
        return result;
    }

    public async Task<int> CountRecoveryCodesAsync(UserRegister userRegister)
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

    public async Task<UserRegister> FindByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

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

    public async Task<UserRegister?> FindByIdAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

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

    public async Task<string> GenerateChangeEmailTokenAsync(UserRegister userRegister, string newEmail)
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

        var result = await _userManager.GenerateChangeEmailTokenAsync(user, newEmail);
        return result;
    }

    public async Task<string> GenerateEmailConfirmationTokenAsync(UserRegister userRegister)
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

        var result = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        return result;
    }

    public async Task<IEnumerable<string>?> GenerateNewTwoFactorRecoveryCodesAsync(UserRegister userRegister, int number)
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
        var result = await _userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, number);
        return result;
        
    }

    public async Task<string> GeneratePasswordResetTokenAsync(UserRegister userRegister)
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
        var result = await _userManager.GeneratePasswordResetTokenAsync(user);
        return result;
    }

    public async Task<string?> GetAuthenticatorKeyAsync(UserRegister userRegister)
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
        var result = await _userManager.GetAuthenticatorKeyAsync(user);
        return result;
    }

    public async Task<string?> GetEmailAsync(UserRegister userRegister)
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
        var result = await _userManager.GetEmailAsync(user);
        return result;
    }

    public async Task<IList<UserLoginInfo>> GetLoginsAsync(User user)
    {
        var result = await _userManager.GetLoginsAsync(user);
        return result;
    }

    public async Task<string?> GetPhoneNumberAsync(UserRegister userRegister)
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
        var result = await _userManager.GetPhoneNumberAsync(user);
        return result;
    }

    public async Task<string> GetSecurityStampAsync(UserRegister userRegister)
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
        var result = await _userManager.GetSecurityStampAsync(user);
        return result;
    }

    public async Task<bool> GetTwoFactorEnabledAsync(UserRegister userRegister)
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
        var result = await _userManager.GetTwoFactorEnabledAsync(user);
        return result;
    }

    public async Task<UserRegister> GetUserAsync(ClaimsPrincipal principal)
    {
        var user = await _userManager.GetUserAsync(principal);

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

    public string? GetUserId(ClaimsPrincipal principal)
    {
        string result = _userManager.GetUserId(principal);
        return result;
    }

    public async Task<string> GetUserIdAsync(UserRegister userRegister)
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

        var result = await _userManager.GetUserIdAsync(user);
        return result;
    }

    public async Task<string?> GetUserNameAsync(UserRegister userRegister)
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
        var result = await _userManager.GetUserNameAsync(user);
        return result;
    }

    public async Task<bool> HasPasswordAsync(UserRegister userRegister)
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
        var result = await _userManager.HasPasswordAsync(user);
        return result;
    }

    public async Task<bool> IsEmailConfirmedAsync(UserRegister userRegister)
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
        var result = await _userManager.IsEmailConfirmedAsync(user);
        return result;
    }

    public async Task<IdentityResult> RemoveLoginAsync(User user, string loginProvider, string providerKey)
    {
        var result = await _userManager.RemoveLoginAsync(user, loginProvider, providerKey);
        return result;
    }

    public async Task<IdentityResult> ResetAuthenticatorKeyAsync(UserRegister userRegister)
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
        var result = await _userManager.ResetAuthenticatorKeyAsync(user);
        return result;
    }

    public async Task<IdentityResult> ResetPasswordAsync(UserRegister userRegister, string token, string newPassword)
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
        var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
        return result;
    }

    public async Task<IdentityResult> SetPhoneNumberAsync(UserRegister userRegister, string? phoneNumber)
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
        var result = await _userManager.SetPhoneNumberAsync(user, phoneNumber);
        return result;
    }

    public async Task<IdentityResult> SetTwoFactorEnabledAsync(UserRegister userRegister, bool enabled)
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
        var result = await _userManager.SetTwoFactorEnabledAsync(user, enabled);
        return result;
    }

    public async Task<IdentityResult> SetUserNameAsync(UserRegister userRegister, string? userName)
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

    public async Task<bool> VerifyTwoFactorTokenAsync(UserRegister userRegister, string tokenProvider, string token)
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
        var result = await _userManager.VerifyTwoFactorTokenAsync(user, tokenProvider, token);
        return result;
    }
}
