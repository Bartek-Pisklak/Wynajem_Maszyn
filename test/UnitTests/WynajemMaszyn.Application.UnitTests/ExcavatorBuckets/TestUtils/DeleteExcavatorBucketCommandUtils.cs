using WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.DeleteExcavatorBuckets;
using WynajemMaszyn.Application.UnitTests.TestUtils.Constants;


namespace WynajemMaszyn.Application.UnitTests.ExcavatorBuckets.TestUtils
{
    public class DeleteExcavatorBucketCommandUtils
    {
        public static DeleteExcavatorBucketCommand DeleteExcavatorBucketCommand() =>
            new DeleteExcavatorBucketCommand(
                Constants.ExcavatorBucket.Id
                );
    }
}
