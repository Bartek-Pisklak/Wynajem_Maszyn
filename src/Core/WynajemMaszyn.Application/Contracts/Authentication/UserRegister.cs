using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WynajemMaszyn.Application.Contracts.Authentication
{
    public class UserRegister : IdentityUser
    {
            public string FirstName { get; set; }
            public string LastName { get; set; }
    }
}
