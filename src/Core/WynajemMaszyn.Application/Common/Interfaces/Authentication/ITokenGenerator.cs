
namespace WynajemMaszyn.Application.Common.Interfaces.Authentication
{
    public interface ITokenGenerator
    {
        string GenerateToken(int userId, string firstName, string lastName, string permission);
    }
}
