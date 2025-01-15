using Microsoft.AspNetCore.Identity;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Contracts.Authentication;

public class RegisterResponse
{
    public User user {  get; set; }
    public IEnumerable<IdentityError>? identityErrors { get; set; }
    public string? userId { get; set; }
    public string? code { get; set; }
    public bool RequireConfirmedAccount { get; set; }
    public bool Succeeded { get; set; }
}