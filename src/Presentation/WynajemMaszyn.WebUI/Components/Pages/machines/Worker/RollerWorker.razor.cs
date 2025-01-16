using Microsoft.AspNetCore.WebUtilities;
using WynajemMaszyn.Application.Features.Rollers.Command.DeleteRollers;
using WynajemMaszyn.Application.Features.Rollers.Queries.DTOs;
using WynajemMaszyn.Application.Features.Rollers.Queries.GetAllRollers;

namespace WynajemMaszyn.WebUI.Components.Pages.machines.Worker
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
                    return rollerResponse;
                },
                errors =>
                {
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"Error: {error.Description} (Code: {error.Code})");
                    }

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
        private void EditRoller(int idMachine)
        {
            string action = "edit";
            var url = QueryHelpers.AddQueryString("/RollerForm", new Dictionary<string, string?>
            {
                { "IdMachine", idMachine.ToString() },
                { "Action", action }
            });
            navigationManager.NavigateTo(url);
        }
        private void DeleteRoller(int idMachine)
        {
            var command = new DeleteRollerCommand(idMachine);

            var response = Mediator.Send(command);
            navigationManager.NavigateTo(navigationManager.Uri, forceLoad: true);
            Console.WriteLine(response.ToString());
        }
    }
}
