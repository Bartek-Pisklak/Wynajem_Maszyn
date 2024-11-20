﻿using System.ComponentModel.DataAnnotations;
using WynajemMaszyn.Application.Authentication.Commands.Login;
using WynajemMaszyn.Application.Authentication.Commands.Register;

namespace WynajemMaszyn.WebUI.Pages.Form
{
    public partial class AccountAuthForm
    {
        private bool isRegistering = false;
        private string formTitle => isRegistering ? "Register" : "Login";
        private string submitButtonText => isRegistering ? "Register" : "Login";
        private string toggleButtonText => isRegistering ? "Already have an account? Log in" : "Don't have an account? Register";

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
                await Mediator.Send(command);
                Console.WriteLine("Logging in user");
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
