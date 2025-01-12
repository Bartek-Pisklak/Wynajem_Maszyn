using Microsoft.AspNetCore.Identity;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Persistance.Auth
{
    public interface IUserManagerService //: UserManager<User>
    {
        Task<SignInResult> LoginAsync(string username, string password);
        Task<IdentityResult> CreateAsync(User user, string password);
        Task<string> GetUserIdAsync(User user);
        Task<string> GenerateEmailConfirmationTokenAsync(User user);

    }
}
