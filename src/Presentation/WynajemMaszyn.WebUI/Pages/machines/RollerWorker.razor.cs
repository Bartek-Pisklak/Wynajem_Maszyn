﻿using WynajemMaszyn.Application.Features.Rollers.Queries.DTOs;
using WynajemMaszyn.Application.Features.Rollers.Queries.GetAllRollers;

namespace WynajemMaszyn.WebUI.Pages.machines
{
    public partial class RollerWorker
    {
        private List<GetAllRollerDto>? roller;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var query = new GetAllRollerQuery();
                var response = await Mediator.Send(query);


                roller = response.Match(
                rollerResponse =>
                {
                    // Zwraca listę koparek, jeśli żadne błędy nie wystąpiły
                    return rollerResponse;
                },
                errors =>
                {
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"Error: {error.Description} (Code: {error.Code})");
                    }

                    // Możesz zwrócić pustą listę lub obsłużyć błędy w inny sposób
                    throw new Exception("Failed to retrieve rollers.");
                }
           );
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"Invalid cast exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unhandled exception: {ex.Message}");
            }
        }

        private void AddRoller()
        {
            navigationManager.NavigateTo("/RollerForm");
        }
        private void EditRoller()
        {
            navigationManager.NavigateTo("/RollerForm");
        }
        private void DeleteRoller()
        {

        }



    }
}