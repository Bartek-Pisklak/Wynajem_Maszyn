using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Persistance
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        bool Any(string email);
        string Add(User user);
        Task<User?> GetUser(string email, string password);
    }
}
