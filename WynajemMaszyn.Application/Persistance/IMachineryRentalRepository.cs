using WynajemMaszyn.Domain.Entities;
namespace WynajemMaszyn.Application.Persistance
{
    public interface IMachineryRentalRepository
    {
        Task <IEnumerable<MachineryRental?>> GetAllMachineryRentalUser(int idUser);
        Task<IEnumerable<MachineryRental?>> GetAllMachineryRentalWorker();
        Task<MachineryRental> GetMachineryRental(int id);

        Task AddMachineryRental(MachineryRental machineryRental);
        Task DeleteMachineryRental(int id);
        Task EditMachineryRental(int id,MachineryRental editedMachineryRental);
    }
}
