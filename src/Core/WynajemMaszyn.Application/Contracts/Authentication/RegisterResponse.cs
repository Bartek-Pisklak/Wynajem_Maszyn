using ErrorOr;
using Microsoft.AspNetCore.Identity;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Contracts.Authentication;

public class RegisterResponse
{

    public string UserId { get; set; }
    public string Email { get; set; }
    public bool RequiresConfirmation { get; set; }
}