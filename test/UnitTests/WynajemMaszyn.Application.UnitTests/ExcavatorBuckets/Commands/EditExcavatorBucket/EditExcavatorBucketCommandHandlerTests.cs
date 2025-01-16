using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Security.Claims;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.EditExcavatorBuckets;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.UnitTests.ExcavatorBuckets.TestUtils;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.UnitTests.ExcavatorBuckets.Commands.EditExcavatorBucket
{
    public class EditExcavatorBucketCommandHandlerTests
    {
        private readonly EditExcavatorBucketCommandHandler _handler;
        private readonly Mock<IExcavatorBucketRepository> _mockEditExcavatorBucketCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<UserManager<User>> _mockUserManager;

        public EditExcavatorBucketCommandHandlerTests()
        {
            _mockEditExcavatorBucketCommandHandler = new Mock<IExcavatorBucketRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockUserManager = new Mock<UserManager<User>>();
            _handler = new EditExcavatorBucketCommandHandler(_mockEditExcavatorBucketCommandHandler.Object, _mockUserManager.Object, _mockMachineryRepositoryHandler.Object);
        }


        [Fact]
        public async Task Handle_Should_ReturnErrorEditExcavator_WhenIsNotValue()
        {
            //arange
            var EditExcavatorBucketCommand = EditExcavatorBucketCommandUtils.EditExcavatorBucketCommand();

            _mockUserManager.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>()))
                .Returns<string>(null);

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

_mockUserManager.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>()))
                .Returns("1");

            //act
            var result = await _handler.Handle(EditExcavatorBucketCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }
    }
}
