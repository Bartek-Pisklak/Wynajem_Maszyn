
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Persistance
{
    public interface IMachineryRepository
    {
        Task<IEnumerable<Machinery?>> GetAllMachinery();
        Task CreateMachinery(Machinery newMachinery);
        Task EditMachinery(Machinery Machinery);
        Task DeleteMachinery(Machinery Machinery);
        Task<IEnumerable<(int Id, DateTime Start, DateTime End)?>?> GetDateMachineryBusy(Machinery wHatMachinery);
        Task<IEnumerable<(DateTime Start, DateTime End)?>?> GetDateOneMachineryBusy(int IdMachinery);
    }
}
