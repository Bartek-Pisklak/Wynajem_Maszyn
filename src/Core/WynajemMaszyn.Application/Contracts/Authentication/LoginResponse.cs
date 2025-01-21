namespace WynajemMaszyn.Application.Contracts.Authentication;

public class LoginResponse
{
    public bool RequiresTwoFactor { get; set; }
    public bool IsLockedOut { get; set; }
    public string? RedirectUrl { get; set; }
}