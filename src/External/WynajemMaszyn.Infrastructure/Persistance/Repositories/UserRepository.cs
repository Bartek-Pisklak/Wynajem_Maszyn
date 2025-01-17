using Microsoft.EntityFrameworkCore;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;


namespace WynajemMaszyn.Infrastructure.Persistance.Repositories
{

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User? GetUserByEmail(string email)
        {
            var user = _dbContext.Users.FirstOrDefault(r => r.Email == email);
            return user;
        }

        public bool Any(string email)
        {
            var isExist = _dbContext.Users.Any(r => r.Email == email);
            return isExist;
        }

        public string Add(User user)
        {
            /*            user.PasswordHash = BC.HashPassword(user.PasswordHash);
                        _dbContext.Users.Add(user);
                        _dbContext.SaveChanges();

                        return user.Id;*/
            return null;
        }

        public async Task<User?> GetUser(string email, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user is null) return null;

            /*
                        var passwordVerification = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

                        if (!passwordVerification) return null;

                        return user;*/
            return null;
        }

    }
}
