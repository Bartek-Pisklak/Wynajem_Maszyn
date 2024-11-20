using Microsoft.EntityFrameworkCore;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Infrastructure.Persistance.Repositories
{
    public class ExcavatorBucketRepository : IExcavatorBucketRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ExcavatorBucketRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateExcavatorBucket(ExcavatorBucket newExcavatorBucket)
        {
            await _dbContext.ExcavatorsBuckets.AddAsync(newExcavatorBucket);
            await _dbContext.SaveChangesAsync();
            return newExcavatorBucket.Id;
        }

        public async Task DeleteExcavatorBucket(int id)
        {
            var result = await _dbContext.ExcavatorsBuckets.FirstOrDefaultAsync(c => c.Id == id);

            if (result == null)
            {
                return;
            }

            _dbContext.ExcavatorsBuckets.Remove(result);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditExcavatorBucket(int id, ExcavatorBucket editedExcavatorBucket)
        {
            var result = await _dbContext.ExcavatorsBuckets.FindAsync(id);

            if (result == null)
            {
                return;
            }
            result.Name = editedExcavatorBucket.Name;
            result.BucketType = editedExcavatorBucket.BucketType;
            result.ProductionYear = editedExcavatorBucket.ProductionYear;
            result.BucketCapacity = editedExcavatorBucket.BucketCapacity;
            result.Weight = editedExcavatorBucket.Weight;

            result.Width = editedExcavatorBucket.Width;
            result.PinDiameter = editedExcavatorBucket.PinDiameter;
            result.ArmWidth = editedExcavatorBucket.ArmWidth;
            result.PinSpacing = editedExcavatorBucket.PinSpacing;

            result.Material = editedExcavatorBucket.Material;
            result.MaxLoadCapacity = editedExcavatorBucket.MaxLoadCapacity;
            result.RentalPricePerDay = editedExcavatorBucket.RentalPricePerDay;
            result.CompatibleExcavators = editedExcavatorBucket.CompatibleExcavators;

            result.ImagePath = editedExcavatorBucket.ImagePath;
            result.Description = editedExcavatorBucket.Description;
            result.IsRepair = editedExcavatorBucket.IsRepair;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExcavatorBucket>> GetAllExcavatorBucket()
        {
            var bucketList = await _dbContext.ExcavatorsBuckets.ToListAsync();

            return bucketList;
        }

        public async Task<ExcavatorBucket?> GetExcavatorBucket(int id)
        {
            var bucket = await _dbContext.ExcavatorsBuckets.FirstOrDefaultAsync(r => r.Id == id);
            return bucket;
        }
    }
}
