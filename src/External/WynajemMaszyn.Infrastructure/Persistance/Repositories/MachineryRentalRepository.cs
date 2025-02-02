﻿using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
using WynajemMaszyn.Application.Features.MachineryRentals.Queries.DTOs;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Domain.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public async Task<IEnumerable<GetMachineDto>> GetMachinerySmallDetails(int id)
        {
            List<Machinery?> machines = await _dbContext.MachineryRentalLists
                .Where(c => c.MachineryRentalId == id)
                .Select(c => c.Machinery)
                .ToListAsync();

            List<GetMachineDto> data = new List<GetMachineDto>();

            foreach (var machine in machines)
            {

                GetMachineDto newData = new();
                newData.Machine = machine;
                newData.Name = machine.Name;
                if (machine.ExcavatorId is not null)
                {
                    var machinery = await _dbContext.Excavators
                        .FirstOrDefaultAsync(c => c.Id == machine.ExcavatorId);
                    newData.RentalPricePerDay = machinery.RentalPricePerDay;
                    newData.ImagePath = machinery.ImagePath.Split(",").FirstOrDefault();
                }
                else if (machine.ExcavatorBucketId is not null)
                {
                    var machinery = await _dbContext.ExcavatorsBuckets
                        .FirstOrDefaultAsync(c => c.Id == machine.ExcavatorBucketId);
                    newData.RentalPricePerDay = machinery.RentalPricePerDay;
                    newData.ImagePath = machinery.ImagePath.Split(",").FirstOrDefault();
                }
                else if (machine.RollerId is not null)
                {
                    var machinery = await _dbContext.Rollers
                        .FirstOrDefaultAsync(c => c.Id == machine.RollerId);
                    newData.RentalPricePerDay = machinery.RentalPricePerDay;
                    newData.ImagePath = machinery.ImagePath.Split(",").FirstOrDefault();
                }
                else if (machine.HarvesterId is not null)
                {
                    var machinery = await _dbContext.Harvesters
                        .FirstOrDefaultAsync(c => c.Id == machine.HarvesterId);
                    newData.RentalPricePerDay = machinery.RentalPricePerDay;
                    newData.ImagePath = machinery.ImagePath.Split(",").FirstOrDefault();
                }
                else if (machine.WoodChipperId is not null)
                {
                    var machinery = await _dbContext.WoodChippers
                        .FirstOrDefaultAsync(c => c.Id == machine.WoodChipperId);
                    newData.RentalPricePerDay = machinery.RentalPricePerDay;
                    newData.ImagePath = machinery.ImagePath.Split(",").FirstOrDefault();
                }
                data.Add(newData);
            }

            return data;
        }


        public async Task<IEnumerable<MachineryRental?>> GetAllMachineryRentalWorker()
        {
            var machineryRentalList = await _dbContext.MachineryRentals.Where(c => c.RentalStatus != RentalStatus.koszyk).ToListAsync();

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

            var cart = await _dbContext.MachineryRentals.FirstOrDefaultAsync(
                        c => c.RentalStatus == RentalStatus.koszyk &&c.UserId == idUser);

            if(cart is null)
            {
                MachineryRental machineryRental = new MachineryRental();
                machineryRental.UserId = idUser;
                cart = await CreateMachineryRental(machineryRental);
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


            var isMachineRental = await _dbContext.MachineryRentalLists.
            FirstOrDefaultAsync(c => c.MachineryId == (int)idMachine && c.MachineryRentalId == cart.Id);

            if(isMachineRental is not null)
            {
                return;
            }

            MachineryRentalList newMachineRental = new MachineryRentalList();
            newMachineRental.MachineryId = (int)idMachine;
            newMachineRental.MachineryRentalId = cart.Id;

            await _dbContext.MachineryRentalLists.AddAsync(newMachineRental);

            var machieneId = idMachine;

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

            float? selectedPrice = rentalPrices.ExcavatorPrice ??
                       rentalPrices.ExcavatorBucketPrice ??
                       rentalPrices.RollerPrice ??
                       rentalPrices.HarvesterPrice ??
                       rentalPrices.WoodChipperPrice;

            if (selectedPrice == null)
            {
                return;
            }

            cart.Cost += selectedPrice.Value;

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

            var machineryDeleteCard = await _dbContext.MachineryRentalLists.
                FirstOrDefaultAsync(c =>c.MachineryId == (int)idMachine && c.MachineryRentalId == cart.Id);

            if( machineryDeleteCard == null )
            {
                return;
            }

            var machieneId = idMachine;

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

            float? selectedPrice = rentalPrices.ExcavatorPrice ??
                       rentalPrices.ExcavatorBucketPrice ??
                       rentalPrices.RollerPrice ??
                       rentalPrices.HarvesterPrice ??
                       rentalPrices.WoodChipperPrice;

            if (selectedPrice == null)
            {
                return;
            }

            cart.Cost -= selectedPrice.Value;

            _dbContext.MachineryRentalLists.Remove(machineryDeleteCard);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ConfirmIdCardUser(int idCard, string idUser)
        {
            var card = await _dbContext.MachineryRentals.FirstOrDefaultAsync(
            c => c.Id == idCard && c.UserId == idUser);

            if( card is not null )
            { 
                return true;
            }

            return false;
        }

        public async Task<int> GetIdCardUser(string idUser)
        {
            var card = await _dbContext.MachineryRentals.FirstOrDefaultAsync(
            c => c.RentalStatus == RentalStatus.koszyk && c.UserId == idUser);

            if (card is null)
            {
                MachineryRental machineryRental = new MachineryRental();
                machineryRental.UserId = idUser;
                card = await CreateMachineryRental(machineryRental);
            }

            return card.Id;
        }

        public async Task CreateRental(MachineryRental machineryRental)
        {
            var result = await _dbContext.MachineryRentals.FirstOrDefaultAsync(
                c => c.Id == machineryRental.Id && c.UserId == machineryRental.UserId);

            if (result == null)
            {
                return;
            }

            result.Cost = machineryRental.Cost;
            result.BeginRent = machineryRental.BeginRent;
            result.EndRent = machineryRental.EndRent;
            result.RentalStatus = machineryRental.RentalStatus;
            result.Deposit = machineryRental.Deposit;
            result.PaymentMethod = machineryRental.PaymentMethod;

            await _dbContext.SaveChangesAsync();

        }
    }
}
