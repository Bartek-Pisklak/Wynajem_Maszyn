using Microsoft.AspNetCore.WebUtilities;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.DeleteExcavatorBuckets;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.DTOs;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.GetAllExcavatorBuckets;


namespace WynajemMaszyn.WebUI_server.Components.Pages.machines.Worker
{
    partial class BucketExcavatorWorker
    {
        private List<GetAllExcavatorBucketDto>? bucketExcavator;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var query = new GetAllExcavatorBucketQuery();
                var response = await Mediator.Send(query);


                bucketExcavator = response.Match(
                bucketExcavatorResponse =>
                {
                    // Zwraca listę koparek, jeśli żadne błędy nie wystąpiły
                    return bucketExcavatorResponse;
                },
                errors =>
                {
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"Error: {error.Description} (Code: {error.Code})");
                    }

                    // Możesz zwrócić pustą listę lub obsłużyć błędy w inny sposób
                    throw new Exception("Failed to retrieve ExcavatorBucket.");
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

        private void AddExcavatorBucket()
        {
            // Przekierowanie do strony z formularzem dodawania koparki
            navigationManager.NavigateTo("/ExcavatorBucketForm");
        }

        private void EditExcavatorBucket(int idMachine)
        {
            string action = "edit";
            var url = QueryHelpers.AddQueryString("/ExcavatorBucketForm", new Dictionary<string, string?>
            {
                { "IdMachine", idMachine.ToString() },
                { "Action", action }
            });
            navigationManager.NavigateTo(url);
        }

        private void DeleteExcavatorBucket(int idMachine)
        {
            var command = new DeleteExcavatorBucketCommand(idMachine);

            var response = Mediator.Send(command);
            navigationManager.NavigateTo(navigationManager.Uri, forceLoad: true);
            Console.WriteLine(response.ToString());
        }
    }
}
