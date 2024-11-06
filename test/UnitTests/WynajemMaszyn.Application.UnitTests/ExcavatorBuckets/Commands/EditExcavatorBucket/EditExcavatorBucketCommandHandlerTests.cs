using FluentAssertions;
using Moq;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.EditExcavatorBuckets;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.ExcavatorBuckets.TestUtils;

namespace WynajemMaszyn.Application.UnitTests.ExcavatorBuckets.Commands.EditExcavatorBucket
{
    public class EditExcavatorBucketCommandHandlerTests
    {
        private readonly EditExcavatorBucketCommandHandler _handler;
        private readonly Mock<IExcavatorBucketRepository> _mockEditExcavatorBucketCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<IUserContextGetIdService> _mockIUserContextGetIdService;

        public EditExcavatorBucketCommandHandlerTests()
        {
            _mockEditExcavatorBucketCommandHandler = new Mock<IExcavatorBucketRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockIUserContextGetIdService = new Mock<IUserContextGetIdService>();
            _handler = new EditExcavatorBucketCommandHandler(_mockEditExcavatorBucketCommandHandler.Object, _mockIUserContextGetIdService.Object, _mockMachineryRepositoryHandler.Object);
        }


        [Fact]
        public async Task Handle_Should_ReturnErrorEditExcavator_WhenIsNotValue()
        {
            //arange
            var EditExcavatorBucketCommand = EditExcavatorBucketCommandUtils.EditExcavatorBucketCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
                .Returns(value: null);

            //act
            var result = await _handler.Handle(EditExcavatorBucketCommand, default);

            //Assert
            result.IsError.Should().BeTrue();

        }


        [Fact]
        public async Task Handle_Should_ReturnEditExcavator_WhenIsValue()
        {
            //arange
            var EditExcavatorBucketCommand = EditExcavatorBucketCommandUtils.EditExcavatorBucketCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
                .Returns(1);

            //act
            var result = await _handler.Handle(EditExcavatorBucketCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }
    }
}
