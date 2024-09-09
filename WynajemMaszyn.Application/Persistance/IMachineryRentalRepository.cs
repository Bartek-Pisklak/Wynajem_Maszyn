using WynajemMaszyn.Domain.Entities;
namespace WynajemMaszyn.Application.Persistance
{
    public interface IMachineryRentalRepository
    {
        IEnumerable<MachinesRental> getAllMachineryRental(int id);
        MachinesRental getMachineryRental(int id, int idUser);
        void addMachineryRental(MachinesRental machineryRental, int idUser);
        void deleteMachineryRental(int id, int idUser);
        void updateMachineryRental(MachinesRental machineryRental, int idUser);
    }
}
