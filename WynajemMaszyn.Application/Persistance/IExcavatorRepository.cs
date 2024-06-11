using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Persistance
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
