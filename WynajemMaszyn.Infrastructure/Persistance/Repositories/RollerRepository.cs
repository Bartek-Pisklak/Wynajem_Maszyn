using Microsoft.EntityFrameworkCore;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Infrastructure.Persistance.Repositories
{
    public class RollerRepository : IRollerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RollerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddRoller(Roller newRoller)
        {
            await _dbContext.Rollers.AddAsync(newRoller);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRoller(int id)
        {
            var result = await _dbContext.Rollers.FirstOrDefaultAsync(c => c.Id == id);
            if (result == null)
            {
                return;
            }
            _dbContext.Rollers.Remove(result);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRoller(int id, Roller editedRoller)
        {
            var result = await _dbContext.Rollers.FirstOrDefaultAsync(c => c.Id == id);

            if (result == null)
            {
                return;
            }







            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Roller?>> GetAllRoller()
        {
            var rollerList = await _dbContext.Rollers.ToListAsync();
            return rollerList;
        }

        public async Task<Roller?> GetRoller(int id)
        {
            var roller = await _dbContext.Rollers.FirstOrDefaultAsync(c => c.Id == id);
            return roller;
        }


    }
}
