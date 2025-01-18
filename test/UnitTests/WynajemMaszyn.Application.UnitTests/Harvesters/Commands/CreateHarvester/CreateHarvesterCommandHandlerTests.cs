using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Security.Claims;
using WynajemMaszyn.Application.Features.Harvesters.Command.CreateHarvesters;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.Harvesters.TestUtils;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.UnitTests.Harvesters.Commands.CreateHarvester
{
    public class CreateHarvesterCommandHandlerTests
    {
        private readonly CreateHarvesterCommandHandler _handler;
        private readonly Mock<IHarvesterRepository> _mockCreateHarvesterCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<ICurrentUserService> _mockUserService;

        public CreateHarvesterCommandHandlerTests()
        {
            _mockCreateHarvesterCommandHandler = new Mock<IHarvesterRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockUserService = new Mock<ICurrentUserService>();
          //  _handler = new CreateHarvesterCommandHandler(_mockCreateHarvesterCommandHandler.Object, _mockUserManager.Object, _mockMachineryRepositoryHandler.Object);

        }

        [Fact]
        public async Task Handle_Should_ReturnErrorCreateHarvester_WhenIsNotValue()
        {
            //arange
            var createHarvesterCommand = CreateHarvesterCommandUtils.CreateHarvesterCommand();


            //act
            var result = await _handler.Handle(createHarvesterCommand, default);

            //Assert
            result.IsError.Should().BeTrue();

        }


        [Fact]
        public async Task Handle_Should_ReturnCreateHarvester_WhenIsValue()
        {
            //arange
            var createHarvesterCommand = CreateHarvesterCommandUtils.CreateHarvesterCommand();


            //act
            var result = await _handler.Handle(createHarvesterCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }
    }
}
