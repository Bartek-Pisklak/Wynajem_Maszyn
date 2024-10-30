using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Persistance
{
    public interface IExcavatorRepository
    {
        Task<Excavator?> GetExcavator(int id);
        Task<IEnumerable<Excavator>> GetAllExcavator();
        Task<int> CreateExcavator(Excavator newExcavator);
        Task DeleteExcavator(int id);
        Task EditExcavator(int id, Excavator editedExcavator);
    }
}
