

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

            if (machinery.IdExcavator == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.IdExcavator == machinery.IdExcavator);
            }
            else if (machinery.IdExcavatorBucket == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.IdExcavatorBucket == machinery.IdExcavatorBucket);
            }
            else if(machinery.IdRoller == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.IdRoller == machinery.IdRoller);
            }
            else if (machinery.IdHarvester == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.IdHarvester == machinery.IdHarvester);
            }
            else if (machinery.IdWoodChipper == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.IdWoodChipper == machinery.IdWoodChipper);
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

            if (machinery.IdExcavator == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.IdExcavator == machinery.IdExcavator);
            }
            else if (machinery.IdExcavatorBucket == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.IdExcavatorBucket == machinery.IdExcavatorBucket);
            }
            else if (machinery.IdRoller == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.IdRoller == machinery.IdRoller);
            }
            else if (machinery.IdHarvester == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.IdHarvester == machinery.IdHarvester);
            }
            else if (machinery.IdWoodChipper == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.IdWoodChipper == machinery.IdWoodChipper);
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
