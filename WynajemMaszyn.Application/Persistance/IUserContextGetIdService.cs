using System.Security.Claims;


namespace WynajemMaszyn.Application.Persistance
{
    public interface IUserContextGetIdService
    {
        int? GetUserId { get; }
        ClaimsPrincipal User { get; }
    }
}
