using WynajemMaszyn.Application.Features.WoodChippers.Queries.GetWoodChippers;
using WynajemMaszyn.Application.UnitTests.TestUtils.Constants;


namespace WynajemMaszyn.Application.UnitTests.WoodChippers.TestUtils
{
    public class GetWoodChipperQueryUtils
    {
        public static GetWoodChipperQuery GetWoodChipperQuery() =>
            new GetWoodChipperQuery(
                Constants.WoodChipper.Id
                );
    }
}
