using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Persistance
{
    public interface IRollerRepository
    {
        Task<Roller?> GetRoller(int id);
        Task<IEnumerable<Roller?>> GetAllRoller();
        Task AddRoller(Roller newRoller);
        Task DeleteRoller(int id);
        Task UpdateRoller(int id, Roller editedRoller);
    }
}
