

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

        public async Task DeleteMachinery(Machinery machinery)
        {
            var result = new Machinery();

            if (machinery.ExcavatorId == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.ExcavatorId == machinery.ExcavatorId);
            }
            else if (machinery.ExcavatorBucketId == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.ExcavatorBucketId == machinery.ExcavatorBucketId);
            }
            else if (machinery.RollerId == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.RollerId == machinery.RollerId);
            }
            else if (machinery.HarvesterId == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.HarvesterId == machinery.HarvesterId);
            }
            else if (machinery.WoodChipperId == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.WoodChipperId == machinery.WoodChipperId);
            }

            if (result == null)
            {
                return;
            }
            _dbContext.Machiners.Remove(result);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditMachinery(Machinery machinery)
        {
            var result = new Machinery();

            if (machinery.ExcavatorId == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.ExcavatorId == machinery.ExcavatorId);
            }
            else if (machinery.ExcavatorBucketId == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.ExcavatorBucketId == machinery.ExcavatorBucketId);
            }
            else if (machinery.RollerId == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.RollerId == machinery.RollerId);
            }
            else if (machinery.HarvesterId == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.HarvesterId == machinery.HarvesterId);
            }
            else if (machinery.WoodChipperId == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.WoodChipperId == machinery.WoodChipperId);
            }

            if (result == null)
            {
                return;
            }

            result.Name = machinery.Name;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Machinery?>> GetAllMachinery()
        {
            var rollerList = await _dbContext.Machiners.ToListAsync();
            return rollerList;
        }
    }
}
