using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.Features.Enums
{
    public partial class EnumsCustomer
    {
        public List<string> GetTypeChassis()
        {
            List<string> chassisValues = Enum.GetValues(typeof(TypeChassis))
                                 .Cast<TypeChassis>()
                                 .Select(c => c.ToString())
                                 .ToList();
            return chassisValues;
        }
    }
}
