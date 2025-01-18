using WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.EditExcavatorBuckets;
using WynajemMaszyn.Application.UnitTests.TestUtils.Constants;

namespace WynajemMaszyn.Application.UnitTests.ExcavatorBuckets.TestUtils
{
    public class EditExcavatorBucketCommandUtils
    {
        public static EditExcavatorBucketCommand EditExcavatorBucketCommand() =>
                new EditExcavatorBucketCommand(
                    Constants.ExcavatorBucket.Id,
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
                    //Constants.ExcavatorBucket.CompatibleExcavators,
                    Constants.ExcavatorBucket.ImagePath,
                    Constants.ExcavatorBucket.Description,
                    Constants.ExcavatorBucket.IsRepair
                );

    }
}
