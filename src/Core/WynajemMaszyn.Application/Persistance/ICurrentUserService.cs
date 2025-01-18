using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WynajemMaszyn.Application.Persistance
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        IEnumerable<string> Roles { get; }
    }
}
