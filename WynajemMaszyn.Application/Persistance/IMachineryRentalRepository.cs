using WynajemMaszyn.Domain.Entities;
namespace WynajemMaszyn.Application.Persistance
{
    public interface IMachineryRentalRepository
    {
        Task <IEnumerable<MachineryRental?>> GetMachineryRental(int id);
        Task<MachineryRental> GetMachineryRental(int id, int idUser);
        Task AddMachineryRental(MachineryRental machineryRental, int idUser);
        Task DeleteMachineryRental(int id, int idUser);
        Task UpdateMachineryRental(MachineryRental machineryRental, int idUser);
    }
}
