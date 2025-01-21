using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
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

        public async Task<IEnumerable<(int Id, DateTime Start, DateTime End)?>?> GetDateMachineryBusy(Machinery wHatMachinery)
        {
            var machineList = wHatMachinery.ExcavatorBucketId == 1 ? await _dbContext.Machiners.Select(m => m.ExcavatorBucketId).ToListAsync() :
                          wHatMachinery.ExcavatorId == 1 ? await _dbContext.Machiners.Select(m => m.ExcavatorId).ToListAsync() :
                          wHatMachinery.HarvesterId == 1 ? await _dbContext.Machiners.Select(m => m.HarvesterId).ToListAsync() :
                          wHatMachinery.RollerId == 1 ? await _dbContext.Machiners.Select(m => m.RollerId).ToListAsync() :
                          wHatMachinery.WoodChipperId == 1 ? await _dbContext.Machiners.Select(m => m.WoodChipperId).ToListAsync() :
                          new List<int?>();

            if (machineList is null)
            {
                return null;
            }

            var rentalDates = await _dbContext.MachineryRentalLists
                        .Where(rl => machineList.Contains(rl.MachineryId))
                        .Select(rl => new
                        {  
                            rl.MachineryRental.BeginRent,
                            rl.MachineryRental.EndRent,
                            rl.Machinery.ExcavatorId,
                            rl.Machinery.ExcavatorBucketId,
                            rl.Machinery.HarvesterId,
                            rl.Machinery.RollerId,
                            rl.Machinery.WoodChipperId
                        })
                        .ToListAsync();

            if (rentalDates is null)
            {
                return null;
            }

            List<(int Id, DateTime Start, DateTime End)?> data = new List<(int Id, DateTime Start, DateTime End)?>();
            foreach (var entry in rentalDates)
            {
                if(entry.EndRent > DateTime.Today)
                {
                    var id = (entry.ExcavatorId ?? entry.ExcavatorBucketId ??
                        entry.HarvesterId ?? entry.RollerId ?? entry.WoodChipperId).Value;
                    data.Add((id,entry.BeginRent, entry.EndRent));
                }
            }

            return data;
        }


        public async Task<IEnumerable<(DateTime Start, DateTime End)?>?> GetDateOneMachineryBusy(Machinery wHatMachinery)
        {
            int? idMachine = null;
            if (wHatMachinery.ExcavatorId is not null)
            {
                var machinery = await _dbContext.Machiners
                    .FirstOrDefaultAsync(c => c.ExcavatorId == wHatMachinery.ExcavatorId);
                idMachine = machinery?.Id;
            }
            else if (wHatMachinery.ExcavatorBucketId is not null)
            {
                var machinery = await _dbContext.Machiners
                    .FirstOrDefaultAsync(c => c.ExcavatorBucketId == wHatMachinery.ExcavatorBucketId);
                idMachine = machinery?.Id;
            }
            else if (wHatMachinery.RollerId is not null)
            {
                var machinery = await _dbContext.Machiners
                    .FirstOrDefaultAsync(c => c.RollerId == wHatMachinery.RollerId);
                idMachine = machinery?.Id;
            }
            else if (wHatMachinery.HarvesterId is not null)
            {
                var machinery = await _dbContext.Machiners
                    .FirstOrDefaultAsync(c => c.HarvesterId == wHatMachinery.HarvesterId);
                idMachine = machinery?.Id;
            }
            else if (wHatMachinery.WoodChipperId is not null)
            {
                var machinery = await _dbContext.Machiners
                    .FirstOrDefaultAsync(c => c.WoodChipperId == wHatMachinery.WoodChipperId);
                idMachine = machinery?.Id;
            }

            var rentalDates = await _dbContext.MachineryRentalLists
                        .Where(rl => rl.MachineryId == idMachine)
                        .Select(rl => new
                        {
                            rl.MachineryRental.BeginRent,
                            rl.MachineryRental.EndRent,
                        })
                        .ToListAsync();

            if (rentalDates is null)
            {
                return null;
            }

            List<(DateTime Start, DateTime End)?> data = new List<(DateTime Start, DateTime End)?>();
            foreach (var entry in rentalDates)
            {
                if (entry.EndRent > DateTime.Today)
                {
                    data.Add((entry.BeginRent, entry.EndRent));
                }
            }

            return data;
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

            if (machinery.ExcavatorId != null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.ExcavatorId == machinery.ExcavatorId);
            }
            else if (machinery.ExcavatorBucketId != null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.ExcavatorBucketId == machinery.ExcavatorBucketId);
            }
            else if (machinery.RollerId != null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.RollerId == machinery.RollerId);
            }
            else if (machinery.HarvesterId != null)
            {
                result = await _dbContext.Machiners.FirstOrDefaultAsync(c => c.HarvesterId == machinery.HarvesterId);
            }
            else if (machinery.WoodChipperId != null)
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
            var machineryList = await _dbContext.Machiners.ToListAsync();
            return machineryList;
        }


    }
}
