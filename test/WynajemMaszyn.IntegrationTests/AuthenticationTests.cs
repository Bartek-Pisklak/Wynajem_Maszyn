using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using WynajemMaszyn.Application.Authentication.Commands.Login;
using WynajemMaszyn.Application.Authentication.Commands.Register;
using WynajemMaszyn.Application.Contracts.Authentication;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Infrastructure.Persistance;
using WynajemMaszyn.IntegrationTests.Helpers;

namespace WynajemMaszyn.IntegrationTests;

public class AuthenticationTests : BaseIntegrationTest
{
    public AuthenticationTests(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task RegisterUser_ForValidModel_ReturnsOk()
    {
        // arrange

        var command = new RegisterCommand(
            FirstName: "Jan",
            LastName: "Nowak",
            Email: "test@test.com",
            Password: "qwerty123",
            ConfirmPassword: "qwerty123"
        );

        // act
        var response = await Sender.Send(command);
        var userId = response.Value.Id;
        
        // assert 
        DbContext.Users.FirstOrDefault(x => x.Id == userId).Should().NotBeNull();
    }
    
    [Fact]
    public async Task RegisterUser_ForInvalidModel_ReturnsBadRequest()
    {
        // arrange
        var command = new RegisterCommand(
            FirstName: "Jan",
            LastName: "Nowak",
            Email: "test.com",
            Password: "qwerty",
            ConfirmPassword: ""
        );
        
        // act
        var response = await Sender.Send(command);
        
        // assert 
        response.Value.Should().BeNull();
    }
}