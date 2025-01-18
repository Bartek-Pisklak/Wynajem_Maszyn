using Moq;
using FluentAssertions;
using WynajemMaszyn.Application.UnitTests.Excavators.TestUtils;
using WynajemMaszyn.Application.Features.Excavators.Command.CreateExcavators;
using WynajemMaszyn.Application.Persistance;
using Microsoft.AspNetCore.Identity;
using WynajemMaszyn.Domain.Entities;
using System.Security.Claims;


namespace WynajemMaszyn.Application.UnitTests.Excavators.Commands.CreateExcavator
{
    public class CreateExcavatorCommandHandlerTests
    {
        private readonly CreateExcavatorCommandHandler _handler;
        private readonly Mock<IExcavatorRepository> _mockCreateExcavatorCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<ICurrentUserService> _mockUserService;


        public CreateExcavatorCommandHandlerTests() 
        {
            _mockCreateExcavatorCommandHandler = new Mock<IExcavatorRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockUserService = new Mock<ICurrentUserService>();
            //_handler = new CreateExcavatorCommandHandler(_mockCreateExcavatorCommandHandler.Object, _mockUserManager.Object,_mockMachineryRepositoryHandler.Object);


        }



        [Fact]
        public async Task Handle_Should_ReturnErrorCreateExcavator_WhenIsNotValue()
        {
            //arange
            var createExcavatorCommand = CreateExcavatorCommandUtils.CreateExcavatorCommand();



            //act
            var result = await _handler.Handle(createExcavatorCommand, default);

            //Assert
            result.IsError.Should().BeTrue();

        }


        [Fact]
        public async Task Handle_Should_ReturnCreateExcavator_WhenIsValue()
        {
            //arange
            var createExcavatorCommand = CreateExcavatorCommandUtils.CreateExcavatorCommand();



            //act
            var result = await _handler.Handle(createExcavatorCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }

    }
}
