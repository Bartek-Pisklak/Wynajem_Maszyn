using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Persistance
{
    public interface IMachineryRepository
    {
        Task<IEnumerable<Machinery?>> GetAllMachinery();
        Task CreateMachinery(Machinery newMachinery);
        Task DeleteMachinery(int id);
    }
}
