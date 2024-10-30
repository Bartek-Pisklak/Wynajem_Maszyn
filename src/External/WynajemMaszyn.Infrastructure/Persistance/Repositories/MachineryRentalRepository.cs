using Microsoft.EntityFrameworkCore;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Infrastructure.Persistance.Repositories
{
    public class MachineryRentalRepository : IMachineryRentalRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MachineryRentalRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateMachineryRental(MachineryRental machineryRental)
        {
            await _dbContext.MachineryRentals.AddAsync(machineryRental);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMachineryRental(int id)
        {
            var result = await _dbContext.MachineryRentals.FirstOrDefaultAsync(c => c.Id == id);
            if (result == null)
            {
                return;
            }
            _dbContext.MachineryRentals.Remove(result);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<MachineryRental?>> GetAllMachineryRentalUser(int idUser)
        {

            var machineryRentalList = await _dbContext.MachineryRentals.Where(c => c.UserId == idUser)
                                                                 .ToListAsync();

            return machineryRentalList;

        }

        public async Task<IEnumerable<MachineryRental?>> GetAllMachineryRentalWorker()
        {
            var machineryRentalList = await _dbContext.MachineryRentals.ToListAsync();

            return machineryRentalList;
        }

        public async Task<MachineryRental> GetMachineryRental(int id)
        {
            var machineryRental = await _dbContext.MachineryRentals.FirstOrDefaultAsync(r => r.Id == id);
            return machineryRental;
        }

        public async Task EditMachineryRental(int id,MachineryRental editedMachineryRental)
        {

            var result = await _dbContext.MachineryRentals.FirstOrDefaultAsync(c => c.Id == id);

            if (result == null)
            {
                return;
            }

            result.BeginRent = editedMachineryRental.BeginRent;
            result.EndRent = editedMachineryRental.EndRent;
            //result.IdMachines = editedMachineryRental.IdMachines;
            result.Cost = editedMachineryRental.Cost;

            _dbContext.SaveChanges();
        }
    }
}
