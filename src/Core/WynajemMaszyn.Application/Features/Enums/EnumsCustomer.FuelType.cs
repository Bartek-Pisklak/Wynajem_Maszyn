
using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.Features.Enums
{
    public partial class EnumsCustomer
    {
        public List<string> GetFuelType()
        {
            List<string> chassisValues = Enum.GetValues(typeof(FuelType))
                                 .Cast<FuelType>()
                                 .Select(c => c.ToString())
                                 .ToList();
            return chassisValues;
        }
    }
}
