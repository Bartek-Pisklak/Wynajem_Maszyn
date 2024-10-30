using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Persistance
{
    public interface IHarvesterRepository
    {
        Task<Harvester?> GetHarvester(int id);
        Task<IEnumerable<Harvester>> GetAllHarvester();
        Task<int> CreateHarvester(Harvester newHarvester);
        Task DeleteHarvester(int id);
        Task EditHarvester(int id, Harvester editedHarvester);
    }
}
