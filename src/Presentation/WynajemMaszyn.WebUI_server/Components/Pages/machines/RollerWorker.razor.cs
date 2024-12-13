using System.Security.Claims;
using WynajemMaszyn.Application.Features.Rollers.Queries.DTOs;
using WynajemMaszyn.Application.Features.Rollers.Queries.GetAllRollers;

namespace WynajemMaszyn.WebUI_server.Components.Pages.machines
{
    public partial class RollerWorker
    {
        private List<GetAllRollerDto>? roller;

        protected override async Task OnInitializedAsync()
        {
            var userId = HttpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var fullName = HttpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;
            var role = HttpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value;

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
