using WynajemMaszyn.Domain.Entities;
namespace WynajemMaszyn.Application.Persistance
{
    public interface IMachineryRentalRepository
    {
        IEnumerable<MachineryRental> getAllMachineryRental(int id);
        MachineryRental getMachineryRental(int id, int idUser);
        void addMachineryRental(MachineryRental machineryRental, int idUser);
        void deleteMachineryRental(int id, int idUser);
        void updateMachineryRental(MachineryRental machineryRental, int idUser);
    }
}
