using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using WynajemMaszyn.Application.Authentication.Commands.Login;
using Microsoft.AspNetCore.Components;
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
        await _httpContextAccessor.HttpContext.SignInAsync(tokenClaim.claimForToken);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, tokenClaim.claimForToken);

        return Ok(new { Message = "Login successful" });
    }
}