using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Persistance
{
    public interface IPermisionRepository
    {
        void editPermision(int id, Permision permision);
    }
}
