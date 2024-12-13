﻿using MediatR;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using WynajemMaszyn.Application.Authentication.Commands.Login;
using WynajemMaszyn.Application.Authentication.Commands.Register;
using WynajemMaszyn.Application.Contracts.Authentication;
using static System.Net.WebRequestMethods;



namespace WynajemMaszyn.WebUI_server.Components.Pages.Form.Account
{
    public partial class AccountAuthForm
    {
        /*        [CascadingParameter]
                public HttpContext? httpContext { get; set; }*/

        private bool isRegistering = false;
        private string formTitle => isRegistering ? "Register" : "Login";
        private string submitButtonText => isRegistering ? "Register" : "Login";
        private string toggleButtonText => isRegistering ? "Already have an account? Log in" : "Don't have an account? Register";



        public string? errorMessage;
        public AuthFormModel formModel = new();
        private LoginResponse tokenClaim;
        private bool islogin = false;


        private void ToggleForm()
        {
            isRegistering = !isRegistering;
            formModel = new(); // Reset the form

        }

        private async Task HandleUserSubmit()
        {
            if (formModel.Email != null ||  formModel.Password != null)
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
                    var loginData = new
                    {
                        Email = formModel.Email,
                        Password = formModel.Password
                    };
                    var command = new LoginCommand(formModel.Email, formModel.Password);
                    var response = await Mediator.Send(command);

                    var tokenClaim = response.Match(
                        success => success,
                        errors =>
                        {
                            foreach (var error in errors)
                                Console.WriteLine($"Error: {error.Description} (Code: {error.Code})");
                            return null;
                        }
                    );

                    /*                    HttpContextAccessor.HttpContext?.Response.Cookies.Append("AuthToken", tokenClaim.claimForToken, new CookieOptions
                                        {
                                            HttpOnly = true,
                                            Secure = true,
                                            SameSite = SameSiteMode.Strict,
                                            Expires = DateTime.Now.AddHours(1)
                                        });
                    */
                    var token = tokenClaim.claimForToken;

                    var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7053/set-auth-token");
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    await Http.SendAsync(request);

                    NavigationManager.NavigateTo("/");
                }

                //var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(loginData), Encoding.UTF8, "application/json");

                //var response = await HttpClient.PostAsync("api/auth/login", content);

                /*                    var response1 = await HttpContext.PostAsJsonAsync("api/auth/login", new
                                    {
                                        Email = formModel.Email,
                                        Password = formModel.Password
                                    });*/

                /*                    var command = new LoginCommand(
                                    formModel.Email,
                                    formModel.Password
                                    );
                                    await Mediator.Send(command);
                                    var response = await Mediator.Send(command);

                                    tokenClaim = response.Match(
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
                                    if (tokenClaim.claimForToken is not null)
                                    {
                                        System.Console.WriteLine("3");
                                        await HttpContextAccessor.HttpContext!.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, tokenClaim.claimForToken);
                                        System.Console.WriteLine("4");
                                        navigationManager.NavigateTo("/");
                                    }*/
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
