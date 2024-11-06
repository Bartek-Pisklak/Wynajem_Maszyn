using WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.GetExcavatorBuckets;
using WynajemMaszyn.Application.UnitTests.TestUtils.Constants;

namespace WynajemMaszyn.Application.UnitTests.ExcavatorBuckets.TestUtils
{
    public class GetExcavatorBucketQueryUtils
    {
        public static GetExcavatorBucketQuery GetExcavatorBucketQuery() =>
                new GetExcavatorBucketQuery(
                    Constants.ExcavatorBucket.Id
        );
    }
}
