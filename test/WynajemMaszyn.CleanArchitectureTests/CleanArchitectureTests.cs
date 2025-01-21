using FluentAssertions;
using NetArchTest.Rules;

namespace WynajemMaszyn.CleanArchitectureTests;

public class CleanArchitectureTests
{
    private const string DomainNamespace = "WynajemMaszyn.Domain";
    private const string ApplicationNamespace = "WynajemMaszyn.Application";
    private const string InfrastructureNamespace = "WynajemMaszyn.Infrastructure";
    private const string WebUINamespace = "WynajemMaszyn.WebUI";

    [Fact]
    public void Domain_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        
        var assembly = typeof(WynajemMaszyn.Domain.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            ApplicationNamespace,
            InfrastructureNamespace,
            WebUINamespace
        };
        
        // Act
        
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult()
            .IsSuccessful;
        
        // Assert

        testResult.Should().BeTrue();
    }
    
    [Fact]
    public void Application_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        
        var assembly = typeof(WynajemMaszyn.Application.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            InfrastructureNamespace,
            WebUINamespace
        };
        
        // Act
        
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult()
            .IsSuccessful;
        
        // Assert

        testResult.Should().BeTrue();
    }


    [Fact]
    public void Infrastructure_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange

        var assembly = typeof(WynajemMaszyn.Infrastructure.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            WebUINamespace
        };

        // Act

        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult()
            .IsSuccessful;

        // Assert

        testResult.Should().BeTrue();
    }

    [Fact]
    public void WebUI_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange

        var assembly = typeof(WynajemMaszyn.WebUI.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            DomainNamespace
        };

        // Act

        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult()
            .IsSuccessful;

        // Assert

        testResult.Should().BeTrue();
    }
}