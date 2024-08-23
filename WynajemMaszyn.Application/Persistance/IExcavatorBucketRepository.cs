using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Persistance
{
    public interface IExcavatorBucketRepository
    {
        ExcavatorBucket GetExcavator(int id);
        IEnumerable<ExcavatorBucket> GetAllExcavator();
        void createExcavator(ExcavatorBucket newExcavatorBucket);
        void deleteExcavator(int Id);
        void editExcavator(int Id, ExcavatorBucket editedExcavatorBucket);
    }
}
