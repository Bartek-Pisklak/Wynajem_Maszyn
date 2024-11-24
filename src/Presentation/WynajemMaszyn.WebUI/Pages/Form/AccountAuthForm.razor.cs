
using System.ComponentModel.DataAnnotations;
using WynajemMaszyn.Application.Authentication.Commands.Login;
using WynajemMaszyn.Application.Authentication.Commands.Register;
using WynajemMaszyn.Application.Contracts.Authentication;



namespace WynajemMaszyn.WebUI.Pages.Form
{
    public partial class AccountAuthForm
    {
        private bool isRegistering = false;
        private string formTitle => isRegistering ? "Register" : "Login";
        private string submitButtonText => isRegistering ? "Register" : "Login";
        private string toggleButtonText => isRegistering ? "Already have an account? Log in" : "Don't have an account? Register";

        private string token;
/*        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountAuthForm(IHttpContextAccessor contextAccessor)
        {
            _httpContextAccessor = contextAccessor;
        }*/
        private AuthFormModel formModel = new();

        private void ToggleForm()
        {
            isRegistering = !isRegistering;
            formModel = new(); // Reset the form
        }

        private async Task HandleUserSubmit()
        {
            // Handle form submission (e.g., send data to API)
            if (isRegistering)
            {
                var command = new RegisterCommand(
                formModel.FirstName,
                formModel.LastName,
                formModel.Email,
                formModel.Password,
                formModel.ConfirmPassword
                );
                await Mediator.Send(command);
                Console.WriteLine("Registering user");
            }
            else
            {
                var command = new LoginCommand(
                formModel.Email,
                formModel.Password
                );

                var response = await Mediator.Send(command);

                LoginResponse responseLogin = response.Match(
               response =>
               {
                   // Zwraca listę koparek, jeśli żadne błędy nie wystąpiły
                   return response;
               },
               errors =>
               {
                   throw new Exception("Failed");
               }
               );

                token = responseLogin.Token;

/*                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,            // Cookie accessible only via HTTP requests
                    Secure = true,              // Only send cookies over HTTPS
                    SameSite = SameSiteMode.Strict, // Protect from CSRF attacks
                    Expires = DateTime.Now.AddHours(1)  // Expiration time for the cookie
                };

                // Save token to cookies
                HttpContextAccessor.HttpContext.Response.Cookies.Append("AuthToken", token, cookieOptions);
*/


            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && !string.IsNullOrEmpty(token))
            {
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,            // Cookie accessible only via HTTP requests
                    Secure = true,              // Only send cookies over HTTPS
                    SameSite = SameSiteMode.Strict, // Protect from CSRF attacks
                    Expires = DateTime.Now.AddHours(1)  // Expiration time for the cookie
                };

                // Save token to cookies
                HttpContextAccessor.HttpContext.Response.Cookies.Append("AuthToken", token, cookieOptions);
            }

        }
        public class AuthFormModel
        {
            // Fields for both login and registration
            public string FirstName { get; set; }
            public string LastName { get; set; }

            [Required(ErrorMessage = "Email is required")]
            [EmailAddress(ErrorMessage = "Invalid email format")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password is required")]
            public string Password { get; set; }

            [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
            public string ConfirmPassword { get; set; }
        }

    }
}
