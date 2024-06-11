
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Interfaces.Repositories
{
    public interface IExcavatorRepository
    {
        Excavator GetExcavator(int id);
        IEnumerable<Excavator> GetAllExcavator();
        void createExcavator(Excavator newExcavator);
        void deleteExcavator(int Id);
        void editExcavator(int Id, Excavator editedExcavator);
    }
}
