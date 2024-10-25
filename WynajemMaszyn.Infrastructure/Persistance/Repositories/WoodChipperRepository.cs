using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Infrastructure.Persistance.Repositories
{
    public class WoodChipperRepository : IWoodChipperRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public WoodChipperRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateWoodChipper(WoodChipper newWoodChipper)
        {
            await _dbContext.WoodChippers.AddAsync(newWoodChipper);
            await _dbContext.SaveChangesAsync();
            return newWoodChipper.Id;
        }

        public async Task DeleteWoodChipper(int id)
        {
            var result = await _dbContext.WoodChippers.FirstOrDefaultAsync(c => c.Id == id);
            if (result == null)
            {
                return;
            }
            _dbContext.WoodChippers.Remove(result);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditWoodChipper(int id, WoodChipper editedWoodChipper)
        {
            var result = await _dbContext.WoodChippers.FirstOrDefaultAsync(c => c.Id == id);

            if (result == null)
            {
                return;
            }
            result.Name = editedWoodChipper.Name;
            result.ProductionYear = editedWoodChipper.ProductionYear;
            result.OperatingHours = editedWoodChipper.OperatingHours;
            result.Weight = editedWoodChipper.Weight;
            result.Engine = editedWoodChipper.Engine;
            result.EnginePower = editedWoodChipper.EnginePower;
            result.DrivingSpeed = editedWoodChipper.DrivingSpeed;

            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<WoodChipper>> GetAllWoodChipper()
        {
            var woodChipperList = await _dbContext.WoodChippers.ToListAsync();

            return woodChipperList;
        }

        public async Task<WoodChipper?> GetWoodChipper(int id)
        {
            var woodChipper = await _dbContext.WoodChippers.FirstOrDefaultAsync(r => r.Id == id);
            return woodChipper;
        }
    }
}
