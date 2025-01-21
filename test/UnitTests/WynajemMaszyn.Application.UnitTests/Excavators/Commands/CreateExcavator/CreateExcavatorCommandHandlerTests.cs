using Moq;
using FluentAssertions;
using WynajemMaszyn.Application.UnitTests.Excavators.TestUtils;
using WynajemMaszyn.Application.Features.Excavators.Command.CreateExcavators;
using WynajemMaszyn.Application.Persistance;
using Microsoft.AspNetCore.Identity;
using WynajemMaszyn.Domain.Entities;
using System.Security.Claims;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.EditExcavatorBuckets;


namespace WynajemMaszyn.Application.UnitTests.Excavators.Commands.CreateExcavator
{
    public class CreateExcavatorCommandHandlerTests
    {
        private readonly CreateExcavatorCommandHandler _handler;
        private readonly Mock<IExcavatorRepository> _mockCreateExcavatorCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<ICurrentUserService> _mockCurrentUserService;


        public CreateExcavatorCommandHandlerTests() 
        {
            _mockCreateExcavatorCommandHandler = new Mock<IExcavatorRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockCurrentUserService = new Mock<ICurrentUserService>();
            _handler = new CreateExcavatorCommandHandler(_mockCreateExcavatorCommandHandler.Object, _mockMachineryRepositoryHandler.Object, _mockCurrentUserService.Object);


        }



        [Fact]
        public async Task Handle_Should_ReturnErrorCreateExcavator_WhenIsNotValue()
        {
            //arange
            var createExcavatorCommand = CreateExcavatorCommandUtils.CreateExcavatorCommand();


            _mockCurrentUserService.Setup(x => x.UserId)
            .Returns(value: null);
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

            _mockCurrentUserService.Setup(x => x.UserId)
            .Returns("1");

            _mockCurrentUserService.Setup(x => x.Roles)
            .Returns(new List<string> { "Worker" });

            //act
            var result = await _handler.Handle(createExcavatorCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }

    }
}
