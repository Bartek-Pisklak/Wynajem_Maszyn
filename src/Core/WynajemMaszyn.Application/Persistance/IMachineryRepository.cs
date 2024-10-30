
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Persistance
{
    public interface IMachineryRepository
    {
        Task<IEnumerable<Machinery?>> GetAllMachinery();
        Task CreateMachinery(Machinery newMachinery);
        Task EditMachinery(Machinery Machinery);
        Task DeleteMachinery(Machinery Machinery);
    }
}
