using Moq;
using FluentAssertions;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.DeleteExcavatorBuckets;
using WynajemMaszyn.Application.UnitTests.ExcavatorBuckets.TestUtils;

namespace WynajemMaszyn.Application.UnitTests.ExcavatorBuckets.Commands.DeleteExcavatorBucket
{
    public class DeleteExcavatorBucketCommandHandlerTests
    {
        private readonly DeleteExcavatorBucketCommandHandler _handler;
        private readonly Mock<IExcavatorBucketRepository> _mockDeleteExcavatorBucketCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<IUserContextGetIdService> _mockIUserContextGetIdService;

        public DeleteExcavatorBucketCommandHandlerTests()
        {
            _mockDeleteExcavatorBucketCommandHandler = new Mock<IExcavatorBucketRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockIUserContextGetIdService = new Mock<IUserContextGetIdService>();
            _handler = new DeleteExcavatorBucketCommandHandler(_mockDeleteExcavatorBucketCommandHandler.Object, _mockIUserContextGetIdService.Object, _mockMachineryRepositoryHandler.Object);
        }


        [Fact]
        public async Task Handle_Should_ReturnErrorDeleteExcavator_WhenIsNotValue()
        {
            //arange
            var deleteExcavatorBucketCommand = DeleteExcavatorBucketCommandUtils.DeleteExcavatorBucketCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
                .Returns(value: null);

            //act
            var result = await _handler.Handle(deleteExcavatorBucketCommand, default);

            //Assert
            result.IsError.Should().BeTrue();

        }


        [Fact]
        public async Task Handle_Should_ReturnDeleteExcavator_WhenIsValue()
        {
            //arange
            var deleteExcavatorBucketCommand = DeleteExcavatorBucketCommandUtils.DeleteExcavatorBucketCommand();

            _mockIUserContextGetIdService.Setup(x => x.GetUserId)
                .Returns("1");

            //act
            var result = await _handler.Handle(deleteExcavatorBucketCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }
    }

}