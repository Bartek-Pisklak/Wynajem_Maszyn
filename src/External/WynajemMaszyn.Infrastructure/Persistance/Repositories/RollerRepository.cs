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

        public async Task<int> CreateRoller(Roller newRoller)
        {
            await _dbContext.Rollers.AddAsync(newRoller);
            await _dbContext.SaveChangesAsync();

            return newRoller.Id;
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

        public async Task EditRoller(int id, Roller editedRoller)
        {
            var result = await _dbContext.Rollers.FirstOrDefaultAsync(c => c.Id == id);

            if (result == null)
            {
                return;
            }

            result.Name = editedRoller.Name;
            result.ProductionYear = editedRoller.ProductionYear;
            result.OperatingHours = editedRoller.OperatingHours;
            result.Weight = editedRoller.Weight;
            result.Engine = editedRoller.Engine;
            result.EnginePower = editedRoller.EnginePower;
            result.DrivingSpeed = editedRoller.DrivingSpeed;
            result.FuelConsumption = editedRoller.FuelConsumption;
            result.FuelType = editedRoller.FuelType;
            result.Gearbox = editedRoller.Gearbox;
            result.NumberOfDrums = editedRoller.NumberOfDrums;
            result.RollerType = editedRoller.RollerType;
            result.DrumWidth = editedRoller.DrumWidth;
            result.MaxCompactionForce = editedRoller.MaxCompactionForce;
            result.IsVibratory = editedRoller.IsVibratory;
            result.KnigeAsfalt = editedRoller.KnigeAsfalt;
            result.ImagePath = editedRoller.ImagePath;
            result.Description = editedRoller.Description;
            result.IsRepair = editedRoller.IsRepair;

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
