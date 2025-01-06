using WynajemMaszyn.Domain.Entities;
namespace WynajemMaszyn.Application.Persistance
{
    public interface IMachineryRentalRepository
    {
        Task <IEnumerable<MachineryRental?>> GetAllMachineryRentalUser(int idUser);
        Task<IEnumerable<MachineryRental?>> GetAllMachineryRentalWorker();
        Task<MachineryRental> GetMachineryRental(int id);

        Task CreateMachineryRental(MachineryRental machineryRental);
        Task DeleteMachineryRental(int id);
        Task EditMachineryRental(int id,MachineryRental editedMachineryRental);


        Task AddMachineryIdToCart(int idMachine, int idUser);
        Task DeleteMachineryIdToCart(int idMachine, int idUser);

    }
}
