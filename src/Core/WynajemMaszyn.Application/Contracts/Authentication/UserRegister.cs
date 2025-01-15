using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WynajemMaszyn.Application.Contracts.Authentication
{
    public class UserDto : IdentityUser
    {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
