using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Security.Claims;
using WynajemMaszyn.Application.Features.WoodChippers.Command.EditWoodChippers;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.WoodChippers.TestUtils;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.UnitTests.WoodChippers.Commands.EditWoodChipper
{
    public class EditWoodChipperCommandHandlerTests
    {
        private readonly EditWoodChipperCommandHandler _handler;
        private readonly Mock<IWoodChipperRepository> _mockEditWoodChipperCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<ICurrentUserService> _mockCurrentUserService;


        public EditWoodChipperCommandHandlerTests()
        {
            _mockEditWoodChipperCommandHandler = new Mock<IWoodChipperRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockCurrentUserService = new Mock<ICurrentUserService>();
            _handler = new EditWoodChipperCommandHandler(_mockEditWoodChipperCommandHandler.Object, 
                _mockMachineryRepositoryHandler.Object, _mockCurrentUserService.Object);

        }

        [Fact]
        public async Task Handle_Should_ReturnErrorEditWoodChipper_WhenIsNotValue()
        {
            //arange
            var editWoodChipperCommand = EditWoodChipperCommandUtils.EditWoodChipperCommand();

            _mockCurrentUserService.Setup(x => x.UserId)
            .Returns(value: null);

            //act
            var result = await _handler.Handle(editWoodChipperCommand, default);

            //Assert
            result.IsError.Should().BeTrue();

        }


        [Fact]
        public async Task Handle_Should_ReturnEditWoodChipper_WhenIsValue()
        {
            //arange
            var editWoodChipperCommand = EditWoodChipperCommandUtils.EditWoodChipperCommand();

            _mockCurrentUserService.Setup(x => x.UserId)
            .Returns("1");

            _mockCurrentUserService.Setup(x => x.Roles)
            .Returns(new List<string> { "Worker" });

            //act
            var result = await _handler.Handle(editWoodChipperCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }
    }
}
