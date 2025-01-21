
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Persistance
{
    public interface IMachineryRepository
    {
        Task<IEnumerable<Machinery?>> GetAllMachinery();
        Task CreateMachinery(Machinery newMachinery);
        Task EditMachinery(Machinery machinery);
        Task DeleteMachinery(Machinery machinery);
        Task<IEnumerable<(int Id, DateTime Start, DateTime End)?>?> GetDateMachineryBusy(Machinery  wHatMachinery);
        Task<IEnumerable<(DateTime Start, DateTime End)?>?> GetDateOneMachineryBusy(Machinery wHatMachinery);
    }
}
