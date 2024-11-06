using WynajemMaszyn.Application.Features.Excavators.Queries.GetExcavators;
using WynajemMaszyn.Application.UnitTests.TestUtils.Constants;


namespace WynajemMaszyn.Application.UnitTests.Excavators.TestUtils
{
    public class GetExcavatorCommandUtils
    {
        public static GetExcavatorQuery GetExcavatorQuery() =>
        new GetExcavatorQuery(
            Constants.Excavator.Id
            );
    }
}
