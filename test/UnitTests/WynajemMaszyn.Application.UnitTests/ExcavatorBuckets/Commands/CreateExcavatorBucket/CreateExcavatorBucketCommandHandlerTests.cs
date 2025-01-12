using Moq;
using FluentAssertions;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.CreateExcavatorBuckets;
using WynajemMaszyn.Application.UnitTests.ExcavatorBuckets.TestUtils;

namespace WynajemMaszyn.Application.UnitTests.ExcavatorBuckets.Commands.CreateExcavatorBucket
{
    public class CreateExcavatorBucketCommandHandlerTests
    {
        private readonly CreateExcavatorBucketCommandHandler _handler;
        private readonly Mock<IExcavatorBucketRepository> _mockCreateExcavatorBucketCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<IUserContextGetIdService> _mockIUserContextGetIdService;


        public CreateExcavatorBucketCommandHandlerTests()
        {
            _mockCreateExcavatorBucketCommandHandler = new Mock<IExcavatorBucketRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockIUserContextGetIdService = new Mock<IUserContextGetIdService>();
            _handler = new CreateExcavatorBucketCommandHandler(_mockCreateExcavatorBucketCommandHandler.Object, _mockIUserContextGetIdService.Object, _mockMachineryRepositoryHandler.Object);


        }


        [Fact]
        public async Task Handle_Should_ReturnErrorCreateExcavator_WhenIsNotValue()
        {
            //arange
            var createExcavatorBucketCommand = CreateExcavatorBucketCommandUtils.CreateExcavatorBucketCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
                .Returns(value: null);

            //act
            var result = await _handler.Handle(createExcavatorBucketCommand, default);

            //Assert
            result.IsError.Should().BeTrue();

        }


        [Fact]
        public async Task Handle_Should_ReturnCreateExcavator_WhenIsValue()
        {
            //arange
            var createExcavatorBucketCommand = CreateExcavatorBucketCommandUtils.CreateExcavatorBucketCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
                .Returns("1");

            //act
            var result = await _handler.Handle(createExcavatorBucketCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }
    }
}


     