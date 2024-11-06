using WynajemMaszyn.Application.Features.Harvesters.Queries.GetHarvesters;
using WynajemMaszyn.Application.UnitTests.TestUtils.Constants;


namespace WynajemMaszyn.Application.UnitTests.Harvesters.TestUtils
{
    public class GetHarvesterQueryUtils
    {
        public static GetHarvesterQuery GetHarvesterQuery() =>
            new GetHarvesterQuery(
                Constants.Harvester.Id
                );
    }
}
