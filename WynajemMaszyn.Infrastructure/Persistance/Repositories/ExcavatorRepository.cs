using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Infrastructure;

namespace WynajemMaszyn.Infrastructure.Persistance.Repositories
{
    public class ExcavatorRepository : IExcavatorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ExcavatorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateExcavator(Excavator newExcavator)
        {
            await _dbContext.Excavators.AddAsync(newExcavator);
            await _dbContext.SaveChangesAsync();
            return newExcavator.Id;
        }

        public async Task DeleteExcavator(int id)
        {
            var result = await _dbContext.Excavators.FirstOrDefaultAsync(c => c.Id == id);
            if (result == null)
            {
                return;
            }
            _dbContext.Excavators.Remove(result);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditExcavator(int id, Excavator editedExcavator)
        {
            var result = await _dbContext.Excavators.FirstOrDefaultAsync(c => c.Id == id);

            if (result == null)
            {
                return;
            }
            result.Name = editedExcavator.Name;
            result.ProductionYear = editedExcavator.ProductionYear;
            result.OperatingHours = editedExcavator.OperatingHours;
            result.Weight = editedExcavator.Weight;
            result.Engine = editedExcavator.Engine;
            result.EnginePower = editedExcavator.EnginePower;
            result.DrivingSpeed = editedExcavator.DrivingSpeed;

            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<Excavator>> GetAllExcavator()
        {
            var excavatorList = await _dbContext.Excavators.ToListAsync();

            return excavatorList;
        }

        public async Task<Excavator?> GetExcavator(int id)
        {
            var excavator = await _dbContext.Excavators.FirstOrDefaultAsync(r => r.Id == id);
            return excavator;
        }
    }
}
