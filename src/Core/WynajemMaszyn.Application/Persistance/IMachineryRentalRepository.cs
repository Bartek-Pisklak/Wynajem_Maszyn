using WynajemMaszyn.Domain.Entities;
namespace WynajemMaszyn.Application.Persistance
{
    public interface IMachineryRentalRepository
    {
        Task <IEnumerable<MachineryRental?>> GetAllMachineryRentalUser(string idUser);
        Task<IEnumerable<MachineryRental?>> GetAllMachineryRentalWorker();
        Task<MachineryRental> GetMachineryRental(int id);

        Task CreateMachineryRental(MachineryRental machineryRental);
        Task DeleteMachineryRental(int id);
        Task EditMachineryRental(int id,MachineryRental editedMachineryRental);


        Task AddMachineryIdToCart(int idMachine, string idUser);
        Task DeleteMachineryIdToCart(int idMachine, string idUser);

    }
}
