
using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.Features.Enums
{
    partial class EnumsCustomer
    {
        public List<string> GetBucketType()
        {
            List<string> bucketType = Enum.GetValues(typeof(BucketType))
                             .Cast<BucketType>()
                             .Select(c => c.ToString())
                             .ToList();
            return bucketType;
        }
    }
}
