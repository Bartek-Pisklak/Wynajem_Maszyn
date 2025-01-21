using Moq;
using FluentAssertions;
using WynajemMaszyn.Application.Features.Harvesters.Command.EditHarvesters;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.Harvesters.TestUtils;

namespace WynajemMaszyn.Application.UnitTests.Harvesters.Commands.EditHarvester
{
    public class EditHarvesterCommandHandlerTests
    {
        private readonly EditHarvesterCommandHandler _handler;
        private readonly Mock<IHarvesterRepository> _mockEditHarvesterCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<ICurrentUserService> _mockCurrentUserService;


        public EditHarvesterCommandHandlerTests()
        {
            _mockEditHarvesterCommandHandler = new Mock<IHarvesterRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockCurrentUserService = new Mock<ICurrentUserService>();
            _handler = new EditHarvesterCommandHandler(_mockEditHarvesterCommandHandler.Object, _mockMachineryRepositoryHandler.Object, _mockCurrentUserService.Object);

        }

        [Fact]
        public async Task Handle_Should_ReturnErrorEditHarvester_WhenIsNotValue()
        {
            //arange
            var editHarvesterCommand = EditHarvesterCommandUtils.EditHarvesterCommand();

            _mockCurrentUserService.Setup(x => x.UserId)
            .Returns(value: null);


            //act
            var result = await _handler.Handle(editHarvesterCommand, default);

            //Assert
            result.IsError.Should().BeTrue();

        }


        [Fact]
        public async Task Handle_Should_ReturnEditHarvester_WhenIsValue()
        {
            //arange
            var editHarvesterCommand = EditHarvesterCommandUtils.EditHarvesterCommand();

            _mockCurrentUserService.Setup(x => x.UserId)
            .Returns("1");

            _mockCurrentUserService.Setup(x => x.Roles)
            .Returns(new List<string> { "Worker" });

            //act
            var result = await _handler.Handle(editHarvesterCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }

    }
}
