using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Persistance
{
    public interface IExcavatorBucketRepository
    {

        Task<ExcavatorBucket?> GetExcavatorBucket(int id);
        Task<IEnumerable<ExcavatorBucket>> GetAllExcavatorBucket();
        Task CreateExcavatorBucket(ExcavatorBucket newExcavatorBucket);
        Task DeleteExcavatorBucket(int id);
        Task EditExcavatorBucket(int id, ExcavatorBucket editedExcavatorBucket);
    }

}