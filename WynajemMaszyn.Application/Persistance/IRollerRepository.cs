
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Persistance
{
    public interface IRollerRepository
    {
        Task<Roller?> GetRoller(int id);
        Task<IEnumerable<Roller?>> GetAllRoller();
        Task CreateRoller(Roller newRoller);
        Task DeleteRoller(int id);
        Task EditRoller(int id, Roller editedRoller);
    }
}
