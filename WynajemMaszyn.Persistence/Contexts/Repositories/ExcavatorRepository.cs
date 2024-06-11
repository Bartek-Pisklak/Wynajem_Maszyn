using BlazorServerCleanArchitecture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using WynajemMaszyn.Application.Interfaces.Repositories;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Persistence.Contexts.Repositories
{
    public class ExcavatorRepository : IExcavatorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ExcavatorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void createExcavator(Excavator newExcavator)
        {

            _dbContext.Excavators.Add(newExcavator);
            _dbContext.SaveChanges();
        }

        public void deleteExcavator(int Id)
        {
            var result = _dbContext.Excavators.SingleOrDefault(c => c.Id == Id);


            _dbContext.Excavators.Remove(result);
            _dbContext.SaveChanges();
        }

        public void editExcavator(int Id, Excavator editedExcavator)
        {
            var result = _dbContext.Excavators.FirstOrDefault(c => c.Id == Id);

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

        public IEnumerable<Excavator> GetAllExcavator()
        {
            var listMachinery = _dbContext.Excavators.ToList();

            return listMachinery;
        }

        public Excavator GetExcavator(int id)
        {
            var machinery = _dbContext.Excavators.FirstOrDefault();
            return machinery;
        }
    }
}
