

using Microsoft.EntityFrameworkCore;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Infrastructure.Persistance.Repositories
{
    public class MachineryRepository : IMachineryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MachineryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task CreateMachinery(Machinery newMachinery)
        {
            await _dbContext.Machiners.AddAsync(newMachinery);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMachinery(int id)
        {
            var result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.Id == id);
            if (result == null)
            {
                return;
            }
            _dbContext.Machiners.Remove(result);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Machinery?>> GetAllMachinery()
        {
            var rollerList = await _dbContext.Machiners.ToListAsync();
            return rollerList;
        }
    }
}
