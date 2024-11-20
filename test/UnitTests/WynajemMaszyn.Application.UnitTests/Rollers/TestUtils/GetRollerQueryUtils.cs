using WynajemMaszyn.Application.UnitTests.TestUtils.Constants;
using WynajemMaszyn.Application.Features.Rollers.Queries.GetRollers;

namespace WynajemMaszyn.Application.UnitTests.Rollers.TestUtils
{
    public class GetRollerQueryUtils
    {
        public static GetRollerQuery GetRollerQuery() =>
            new GetRollerQuery(
                Constants.Roller.Id
                );
    }
}
