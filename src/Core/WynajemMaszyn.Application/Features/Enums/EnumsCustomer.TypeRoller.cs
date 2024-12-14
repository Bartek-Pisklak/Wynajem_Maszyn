
using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.Features.Enums
{
    public partial class EnumsCustomer
    {
        public List<string> GetTypeRoller()
        {
            List<string> chassisValues = Enum.GetValues(typeof(RollerType))
                                 .Cast<RollerType>()
                                 .Select(c => c.ToString())
                                 .ToList();


            return chassisValues;
        }
    }
}
