using WynajemMaszyn.Application.UnitTests.TestUtils.Constants;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.CreateExcavatorBuckets;


namespace WynajemMaszyn.Application.UnitTests.ExcavatorBuckets.TestUtils
{
    public class CreateExcavatorBucketCommandUtils
    {

        public static CreateExcavatorBucketCommand CreateExcavatorBucketCommand() =>
                new CreateExcavatorBucketCommand(
                    Constants.ExcavatorBucket.Name,
                    Constants.ExcavatorBucket.BucketType,
                    Constants.ExcavatorBucket.ProductionYear,
                    Constants.ExcavatorBucket.BucketCapacity,
                    Constants.ExcavatorBucket.Weight,
                    Constants.ExcavatorBucket.Width,
                    Constants.ExcavatorBucket.PinDiameter,
                    Constants.ExcavatorBucket.ArmWidth,
                    Constants.ExcavatorBucket.PinSpacing,
                    Constants.ExcavatorBucket.Material,
                    Constants.ExcavatorBucket.MaxLoadCapacity,
                    Constants.ExcavatorBucket.RentalPricePerDay,
                    Constants.ExcavatorBucket.CompatibleExcavators,
                    Constants.ExcavatorBucket.ImagePath,
                    Constants.ExcavatorBucket.Description
                    );
    }
}
