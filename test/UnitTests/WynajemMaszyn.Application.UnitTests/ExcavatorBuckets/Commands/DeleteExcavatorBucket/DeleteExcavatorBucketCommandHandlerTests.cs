using Moq;
using FluentAssertions;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.DeleteExcavatorBuckets;
using WynajemMaszyn.Application.UnitTests.ExcavatorBuckets.TestUtils;
using WynajemMaszyn.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace WynajemMaszyn.Application.UnitTests.ExcavatorBuckets.Commands.DeleteExcavatorBucket
{
    public class DeleteExcavatorBucketCommandHandlerTests
    {
        private readonly DeleteExcavatorBucketCommandHandler _handler;
        private readonly Mock<IExcavatorBucketRepository> _mockDeleteExcavatorBucketCommandHandler;
        private readonly Mock<IMachineryRepository> _mockMachineryRepositoryHandler;
        private readonly Mock<UserManager<User>> _mockUserManager;

        public DeleteExcavatorBucketCommandHandlerTests()
        {
            _mockDeleteExcavatorBucketCommandHandler = new Mock<IExcavatorBucketRepository>();
            _mockMachineryRepositoryHandler = new Mock<IMachineryRepository>();
            _mockUserManager = new Mock<UserManager<User>>();
           // _handler = new DeleteExcavatorBucketCommandHandler(_mockDeleteExcavatorBucketCommandHandler.Object, _mockUserManager.Object, _mockMachineryRepositoryHandler.Object);
        }


        [Fact]
        public async Task Handle_Should_ReturnErrorDeleteExcavator_WhenIsNotValue()
        {
            //arange
            var deleteExcavatorBucketCommand = DeleteExcavatorBucketCommandUtils.DeleteExcavatorBucketCommand();

_mockUserManager.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>()))
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

_mockUserManager.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>()))
                .Returns("1");

            //act
            var result = await _handler.Handle(deleteExcavatorBucketCommand, default);

            //Assert
            result.IsError.Should().BeFalse();

        }
    }

}