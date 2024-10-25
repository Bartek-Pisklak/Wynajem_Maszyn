
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Persistance
{
    public interface IWoodChipperRepository
    {
        Task<IEnumerable<WoodChipper>> GetAllWoodChipper();
        Task<WoodChipper?> GetWoodChipper(int id);
        Task<int> CreateWoodChipper(WoodChipper newWoodChipper);
        Task DeleteWoodChipper(int id);
        Task EditWoodChipper(int id, WoodChipper editedWoodChipper);
    }
}
