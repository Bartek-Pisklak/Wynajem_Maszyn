using Microsoft.EntityFrameworkCore;
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

        public async Task<MachineryRental> CreateMachineryRental(MachineryRental machineryRental)
        {
            await _dbContext.MachineryRentals.AddAsync(machineryRental);
            await _dbContext.SaveChangesAsync();
            return machineryRental;
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




        public async Task AddMachineryIdToCart(Machinery machine, string idUser)
        {

            MachineryRentalList newMachineRental = new MachineryRentalList();

            var cart = await _dbContext.MachineryRentals.FirstOrDefaultAsync(
                        c => c.RentalStatus == RentalStatus.koszyk &&c.UserId == idUser);

            if(cart is null)
            {
                MachineryRental machineryRental = new MachineryRental();
                machineryRental.UserId = idUser;
                cart = await CreateMachineryRental(machineryRental);
            }

            newMachineRental.MachineryId = machine.Id;
            newMachineRental.MachineryRentalId = cart.Id;
            await _dbContext.MachineryRentalLists.AddAsync(newMachineRental);

            var machieneId = machine.Id;

            var rentalPrices = await _dbContext.Machiners
                .Where(m => m.Id == machieneId) // Dopasowanie maszyny po Id
                .Select(m => new
                {
                    ExcavatorPrice = m.ExcavatorId != null ? m.Excavator.RentalPricePerDay : (float?)null,
                    ExcavatorBucketPrice = m.ExcavatorBucketId != null ? m.ExcavatorBucket.RentalPricePerDay : (float?)null,
                    RollerPrice = m.RollerId != null ? m.Roller.RentalPricePerDay : (float?)null,
                    HarvesterPrice = m.HarvesterId != null ? m.Harvester.RentalPricePerDay : (float?)null,
                    WoodChipperPrice = m.WoodChipperId != null ? m.WoodChipper.RentalPricePerDay : (float?)null
                })
                .FirstOrDefaultAsync();



            cart.Cost += (rentalPrices.ExcavatorPrice ?? rentalPrices.ExcavatorBucketPrice ??
                          rentalPrices.RollerPrice ?? rentalPrices.HarvesterPrice ??
                          rentalPrices.WoodChipperPrice).Value;

            await _dbContext.SaveChangesAsync();
        }


        public async Task DeleteMachineryIdToCart(Machinery machine, string idUser)
        {
            var cart = await _dbContext.MachineryRentals.FirstOrDefaultAsync(
            c => c.RentalStatus == RentalStatus.koszyk &&c.UserId == idUser);

            if (cart == null)
            {
                return;
            }

            int? idMachine = null;
            if (machine.ExcavatorId is not null)
            {
                var machinery = await _dbContext.Machiners
                    .FirstOrDefaultAsync(c => c.ExcavatorId == machine.ExcavatorId);
                idMachine = machinery?.Id;
            }
            else if (machine.ExcavatorBucketId is not null)
            {
                var machinery = await _dbContext.Machiners
                    .FirstOrDefaultAsync(c => c.ExcavatorBucketId == machine.ExcavatorBucketId);
                idMachine = machinery?.Id;
            }
            else if (machine.RollerId is not null)
            {
                var machinery = await _dbContext.Machiners
                    .FirstOrDefaultAsync(c => c.RollerId == machine.RollerId);
                idMachine = machinery?.Id;
            }
            else if (machine.HarvesterId is not null)
            {
                var machinery = await _dbContext.Machiners
                    .FirstOrDefaultAsync(c => c.HarvesterId == machine.HarvesterId);
                idMachine = machinery?.Id;
            }
            else if (machine.WoodChipperId is not null)
            {
                var machinery = await _dbContext.Machiners
                    .FirstOrDefaultAsync(c => c.WoodChipperId == machine.WoodChipperId);
                idMachine = machinery?.Id;
            }


            if (idMachine == null)
            {
                return;
            }

            MachineryRentalList machineryDeleteCard = new MachineryRentalList();
            machineryDeleteCard.MachineryId = (int)idMachine;
            machineryDeleteCard.MachineryRentalId = cart.Id;

            _dbContext.MachineryRentalLists.Remove(machineryDeleteCard);
            await _dbContext.SaveChangesAsync();
        }

    }
}
