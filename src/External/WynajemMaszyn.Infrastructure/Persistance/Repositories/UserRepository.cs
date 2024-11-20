using Microsoft.EntityFrameworkCore;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using BC = BCrypt.Net.BCrypt;


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

        public int Add(User user)
        {
            user.Password = BC.HashPassword(user.Password);
            user.PermissionId = 1;
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }

        public async Task<User?> GetUser(string email, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user is null) return null;


            var passwordVerification = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (!passwordVerification) return null;

            return user;
        }

        public async Task<String> GetUserPermission(int permissionId)
        {
            var userPermision = await _dbContext.Permissions.FirstOrDefaultAsync(x => x.Id == permissionId);

            if (userPermision is null) return null;

            return userPermision.Name;
        }
    }
}
