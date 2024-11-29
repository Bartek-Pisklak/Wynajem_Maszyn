using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WynajemMaszyn.Application.Common.Interfaces.Authentication
{
    public interface ITokenGenerator
    {
        ClaimsPrincipal? GenerateToken(int userId, string firstName, string lastName, string permission);
    }
}
