﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Infrastructure.Persistance.Repositories
{
    public class HarvesterRepository : IHarvesterRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public HarvesterRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateHarvester(Harvester newHarvester)
        {
            await _dbContext.Harvesters.AddAsync(newHarvester);
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteHarvester(int id)
        {
            var result = await _dbContext.Harvesters.FirstOrDefaultAsync(c => c.Id == id);
            if (result == null)
            {
                return;
            }
            _dbContext.Harvesters.Remove(result);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditHarvester(int id, Harvester editedHarvester)
        {
            var result = await _dbContext.Harvesters.FirstOrDefaultAsync(c => c.Id == id);

            if (result == null)
            {
                return;
            }
            result.Name = editedHarvester.Name;
            result.ProductionYear = editedHarvester.ProductionYear;
            result.OperatingHours = editedHarvester.OperatingHours;
            result.Weight = editedHarvester.Weight;
           /* result.Engine = editedHarvester.Engine;
            result.EnginePower = editedHarvester.EnginePower;
            result.DrivingSpeed = editedHarvester.DrivingSpeed;*/

            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<Harvester>> GetAllHarvester()
        {
            var harvastorList = await _dbContext.Harvesters.ToListAsync();

            return harvastorList;
        }

        public async Task<Harvester?> GetHarvester(int id)
        {
            var harvester = await _dbContext.Harvesters.FirstOrDefaultAsync(r => r.Id == id);
            return harvester;
        }
    }
}