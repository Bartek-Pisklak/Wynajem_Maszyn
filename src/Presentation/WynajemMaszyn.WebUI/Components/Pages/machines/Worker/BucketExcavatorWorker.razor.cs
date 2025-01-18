using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.WebUtilities;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.DeleteExcavatorBuckets;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.DTOs;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.GetAllExcavatorBuckets;


namespace WynajemMaszyn.WebUI.Components.Pages.machines.Worker
{
    partial class BucketExcavatorWorker
    {
        [CascadingParameter]
        private HttpContext HttpContext { get; set; } = default!;

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
                    return bucketExcavatorResponse;
                },
                errors =>
                {
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"Error: {error.Description} (Code: {error.Code})");
                    }

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
            navigationManager.NavigateTo(navigationManager.Uri);
            Console.WriteLine(response.ToString());
        }
    }
}
