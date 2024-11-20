namespace WynajemMaszyn.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    void GenerateToken(int userId, string firstName, string lastName, string permission);
}