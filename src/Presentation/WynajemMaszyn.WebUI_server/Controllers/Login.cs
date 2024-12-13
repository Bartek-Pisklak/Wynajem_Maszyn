using MediatR;
using WynajemMaszyn.Application.Authentication.Commands.Login;
using Microsoft.AspNetCore.Mvc;
using StudentsDashboard.Api.Controllers;


namespace WynajemMaszyn.WebUI_server.Controllers;


[Microsoft.AspNetCore.Mvc.Route("api/auth")]
public class LoginControler : ApiController
{
    private readonly ISender _mediator;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LoginControler(IMediator mediator, IHttpContextAccessor contextAccessor)
    {
        _mediator = mediator;
        _httpContextAccessor = contextAccessor;
    }

    [HttpGet]
    public IActionResult SetAuthToken()
    {
        // Logika ustawiania ciasteczka




        return Ok();
    }



    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var response = await _mediator.Send(command);


        var tokenClaim = response.Match(
        LoginResponse =>
        {
            return LoginResponse;
        },
        errors =>
        {
            foreach (var error in errors)
            {
                Console.WriteLine($"Error: {error.Description} (Code: {error.Code})");
            }

            // Możesz zwrócić pustą listę lub obsłużyć błędy w inny sposób
            throw new Exception("Failed to retrieve excavators.");
        }
        );
        var token = tokenClaim.claimForToken;


        // Ustaw token w ciasteczku
        Response.Cookies.Append("AuthToken", token, new CookieOptions
        {
            HttpOnly = true, // Zabezpieczenie przed dostępem z JavaScript
            Secure = true, // Wymaga HTTPS
            SameSite = SameSiteMode.Strict, // Zapobiega wysyłaniu ciasteczka z zewnętrznych domen
            Expires = DateTime.Now.AddHours(1) // Data wygaśnięcia ciasteczka
        });

        return Ok();
    }
}