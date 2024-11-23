

using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.Features.Enums
{
    public partial class EnumsCustomer
    {
        public List<string> GetTypeExcavator()
        {
            List<string> chassisValues = Enum.GetValues(typeof(TypeExcavator))
                                 .Cast<TypeExcavator>()
                                 .Select(c => c.ToString())
                                 .ToList();


            return chassisValues;
        }


    }
}
