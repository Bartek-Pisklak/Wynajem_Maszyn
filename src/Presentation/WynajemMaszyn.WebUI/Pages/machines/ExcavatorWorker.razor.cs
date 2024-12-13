﻿using WynajemMaszyn.Application.Features.Excavators.Queries.DTOs;
using WynajemMaszyn.Application.Features.Excavators.Queries.GetAllExcavators;


namespace WynajemMaszyn.WebUI.Pages.machines
{
    public partial class ExcavatorWorker
    {

        private List<GetAllExcavatorDto>? excavator;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var query = new GetAllExcavatorQuery();
                var response = await Mediator.Send(query);


                excavator = response.Match(
                excavatorResponse =>
                {
                    // Zwraca listę koparek, jeśli żadne błędy nie wystąpiły
                    return excavatorResponse;
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

        private void AddExcavator()
        {
            // Przekierowanie do strony z formularzem dodawania koparki
            navigationManager.NavigateTo("/ExcavatorForm");
        }

        private void EditExcavator()
        {

        }

        private void DeleteExcavator()
        {

        }

    }
}