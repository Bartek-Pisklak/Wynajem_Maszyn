using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Persistance.Auth
{
    public interface IUserAccessor
    {
        Task<User> GetRequiredUserAsync(HttpContext context);
    }
}
