using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Persistance
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        bool Any(string email);
        int Add(User user);
        Task<User?> GetUser(string email, string password);
    }
}
