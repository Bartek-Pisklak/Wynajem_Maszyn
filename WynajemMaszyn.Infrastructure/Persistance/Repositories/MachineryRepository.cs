

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

        public async Task DeleteMachinery(Machinery newMachinery)
        {
            var result = new Machinery();

            if (newMachinery.IdExcavator == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.IdExcavator == newMachinery.IdExcavator);
            }
            else if (newMachinery.IdExcavatorBucket == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.IdExcavatorBucket == newMachinery.IdExcavatorBucket);
            }
            else if(newMachinery.IdRoller == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.IdRoller == newMachinery.IdRoller);
            }
            else if (newMachinery.IdHarvester == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.IdHarvester == newMachinery.IdHarvester);
            }
            else if (newMachinery.IdWoodChipper == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.IdWoodChipper == newMachinery.IdWoodChipper);
            }

            if (result == null)
            {
                return;
            }
            _dbContext.Machiners.Remove(result);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditMachinery(Machinery newMachinery)
        {
            var result = new Machinery();

            if (newMachinery.IdExcavator == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.IdExcavator == newMachinery.IdExcavator);
            }
            else if (newMachinery.IdExcavatorBucket == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.IdExcavatorBucket == newMachinery.IdExcavatorBucket);
            }
            else if (newMachinery.IdRoller == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.IdRoller == newMachinery.IdRoller);
            }
            else if (newMachinery.IdHarvester == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.IdHarvester == newMachinery.IdHarvester);
            }
            else if (newMachinery.IdWoodChipper == null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.IdWoodChipper == newMachinery.IdWoodChipper);

            }

            if (result == null)
            {
                return;
            }

            result.Name = newMachinery.Name;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Machinery?>> GetAllMachinery()
        {
            var rollerList = await _dbContext.Machiners.ToListAsync();
            return rollerList;
        }
    }
}
