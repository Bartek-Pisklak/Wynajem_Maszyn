using System.Security.Claims;


namespace WynajemMaszyn.Application.Persistance
{
    public interface IUserContextGetIdService
    {
        string? GetUserId { get; }
        ClaimsPrincipal User { get; }
    }
}
