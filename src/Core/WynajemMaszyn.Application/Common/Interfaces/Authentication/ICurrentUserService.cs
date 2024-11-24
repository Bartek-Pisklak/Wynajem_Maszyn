using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WynajemMaszyn.Application.Common.Interfaces.Authentication
{
    public interface ICurrentUserService
    {
        int? GetUserId { get; }
        string GetPermission { get; }
    }
}
