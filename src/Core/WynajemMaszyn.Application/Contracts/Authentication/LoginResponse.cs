using System.Security.Claims;

namespace WynajemMaszyn.Application.Contracts.Authentication;
public class LoginResponse
{
   public int Id { get; set; }
   public string? claimForToken { get; set; }
}