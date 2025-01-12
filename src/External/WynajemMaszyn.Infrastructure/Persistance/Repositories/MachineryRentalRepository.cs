using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Domain.Enums;

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

        public async Task<IEnumerable<MachineryRental?>> GetAllMachineryRentalUser(string idUser)
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

            result.Cost = editedMachineryRental.Cost;
            result.BeginRent = editedMachineryRental.BeginRent;
            result.EndRent = editedMachineryRental.EndRent;
            result.RentalStatus = editedMachineryRental.RentalStatus;
            result.Deposit = editedMachineryRental.Deposit;
            result.LateFee = editedMachineryRental.LateFee;
            result.PaymentMethod = editedMachineryRental.PaymentMethod;
            result.Facture = editedMachineryRental.Facture;
            result.Contract = editedMachineryRental.Contract;
            result.PaymentMethod = editedMachineryRental.PaymentMethod;
            result.AdditionalNotes = editedMachineryRental.AdditionalNotes;
            result.IsReturned = editedMachineryRental.IsReturned;


            await _dbContext.SaveChangesAsync();
        }




        public async Task AddMachineryIdToCart(MachineryRentalList machine)
        {

            await _dbContext.MachineryRentalLists.AddAsync(machine);
            await _dbContext.SaveChangesAsync();

        }

        public async Task AddMachineryIdToCart(int idMachine, string idUser)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteMachineryIdToCart(int idMachine, string idUser)
        {

            var result = await _dbContext.MachineryRentalLists.FirstOrDefaultAsync(c => c.MachineryId == idMachine);
            if (result == null)
            {
                return;
            }

            _dbContext.MachineryRentalLists.Remove(result);
            await _dbContext.SaveChangesAsync();
        }

    }
}
