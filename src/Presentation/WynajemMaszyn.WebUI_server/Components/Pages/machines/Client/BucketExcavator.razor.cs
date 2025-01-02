using Microsoft.AspNetCore.WebUtilities;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.DTOs;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.GetAllExcavatorBuckets;

namespace WynajemMaszyn.WebUI_server.Components.Pages.machines.Client
{
    partial class BucketExcavator
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


        private void NavigateToDetails(int machineId)
        {
            var url = QueryHelpers.AddQueryString("/BucketExcavatorDetails", new Dictionary<string,string?>
            {
                { "IdMachine", machineId.ToString() }
            });
            navigationManager.NavigateTo(url);
        }

    }

}
