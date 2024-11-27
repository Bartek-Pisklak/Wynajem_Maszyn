using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WynajemMaszyn.Application.Common.Interfaces.Authentication
{
    public interface ITokenGenerator
    {
        void GenerateToken(int userId, string firstName, string lastName, string permission);
    }
}
