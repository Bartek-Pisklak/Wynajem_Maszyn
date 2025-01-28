using WynajemMaszyn.Domain.Entities;
namespace WynajemMaszyn.Application.Persistance
{
    public interface IMachineryRentalRepository
    {
        Task <IEnumerable<MachineryRental?>> GetAllMachineryRentalUser(string idUser);
        Task<IEnumerable<MachineryRental?>> GetAllMachineryRentalWorker();
        Task<MachineryRental> GetMachineryRental(int id);


        Task DeleteMachineryRental(int id);
        Task EditMachineryRental(int id,MachineryRental editedMachineryRental);
        Task<bool> ConfirmIdCardUser(int idCard, string idUser);

        Task<MachineryRental> CreateMachineryRental(MachineryRental machineryRental);
        Task AddMachineryIdToCart(Machinery idMachine, string idUser);
        Task DeleteMachineryIdToCart(Machinery idMachine, string idUser);

    }
}
