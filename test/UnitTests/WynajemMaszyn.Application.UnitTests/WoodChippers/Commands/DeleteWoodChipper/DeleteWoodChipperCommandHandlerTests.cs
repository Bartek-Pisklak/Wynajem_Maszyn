using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Security.Claims;
using WynajemMaszyn.Application.Features.WoodChippers.Command.DeleteWoodChippers;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.WoodChippers.TestUtils;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.UnitTests.WoodChippers.Commands.DeleteWoodChipper
{
    public class DeleteWoodChipperCommandHandlerTests
    {
        private readonly DeleteWoodChipperCommandHandler _handler;
        private readonly Mock<IWoodChipperRepository> _mockDeleteWoodChipperCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<ICurrentUserService> _mockCurrentUserService;

        public DeleteWoodChipperCommandHandlerTests()
        {
            _mockDeleteWoodChipperCommandHandler = new Mock<IWoodChipperRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockCurrentUserService = new Mock<ICurrentUserService>();
            _handler = new DeleteWoodChipperCommandHandler(_mockDeleteWoodChipperCommandHandler.Object, _mockMachineryRepositoryHandler.Object, _mockCurrentUserService.Object);

        }


        [Fact]
        public async Task Handle_Should_ReturnErrorDeleteWoodChipper_WhenIsNotValue()
        {
            //arange
            var deleteWoodChipperCommand = DeleteWoodChipperCommandUtils.DeleteWoodChipperCommand();

            _mockCurrentUserService.Setup(x => x.UserId)
            .Returns(value: null);

            //act
            var result = await _handler.Handle(deleteWoodChipperCommand, default);

            //Assert
            result.IsError.Should().BeTrue();

        }


        [Fact]
        public async Task Handle_Should_ReturnDeleteWoodChipper_WhenIsValue()
        {
            //arange
            var deleteWoodChipperCommand = DeleteWoodChipperCommandUtils.DeleteWoodChipperCommand();

            _mockCurrentUserService.Setup(x => x.UserId)
            .Returns("1");

            _mockCurrentUserService.Setup(x => x.Roles)
            .Returns(new List<string> { "Worker" });

            //act
            var result = await _handler.Handle(deleteWoodChipperCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }
    }
}
