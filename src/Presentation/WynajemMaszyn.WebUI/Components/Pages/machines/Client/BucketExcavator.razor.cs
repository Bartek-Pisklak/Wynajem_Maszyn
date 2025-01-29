using Microsoft.AspNetCore.WebUtilities;
using WynajemMaszyn.Application.Features.Enums;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.DTOs;
using WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.GetAllExcavatorBuckets;

namespace WynajemMaszyn.WebUI.Components.Pages.machines.Client
{
    partial class BucketExcavator
    {

        private List<GetAllExcavatorBucketDto>? bucketExcavator;
        private List<string> listBucketTypes = new();

        private string selectedBucketType;
        private int? minYear, maxYear;
        private int? minWeight, maxWeight;
        private float? minPrice, maxPrice;
        private DateTime? startDate, endDate;
        private bool showInRepair = false;

        private List<GetAllExcavatorBucketDto> filteredBuckets = new();

        private void SearchBuckets()
        {
            filteredBuckets = bucketExcavator.Where(b =>
                (string.IsNullOrEmpty(selectedBucketType) || b.BucketType == selectedBucketType) &&
                (!minYear.HasValue || b.ProductionYear >= minYear) &&
                (!maxYear.HasValue || b.ProductionYear <= maxYear) &&
                (!minWeight.HasValue || b.Weight >= minWeight) &&
                (!maxWeight.HasValue || b.Weight <= maxWeight) &&
                (!minPrice.HasValue || b.RentalPricePerDay >= minPrice) &&
                (!maxPrice.HasValue || b.RentalPricePerDay <= maxPrice) &&
                (showInRepair || !b.IsRepair) &&
                (CheckAvailability(b, startDate, endDate)) 
            ).ToList();
        }

        private bool CheckAvailability(GetAllExcavatorBucketDto bucket, DateTime? start, DateTime? end)
        {
            if (!start.HasValue || !end.HasValue)
                return true; 

            return !bucket.DateBusyAll.Any(d =>
                d.HasValue && (
                    (start.Value >= d.Value.Start && start.Value <= d.Value.End) || 
                    (end.Value >= d.Value.Start && end.Value <= d.Value.End) || 
                    (start.Value <= d.Value.Start && end.Value >= d.Value.End) 
                )
            );
        }

        private void ResetSearchMachines()
        {
            filteredBuckets = bucketExcavator;
        }

        protected override async Task OnInitializedAsync()
        {
            EnumsCustomer enumsCustomer = new EnumsCustomer();
            listBucketTypes.Clear();
            listBucketTypes.AddRange(enumsCustomer.GetBucketType());

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
            filteredBuckets = bucketExcavator;
        }


        private void NavigateToDetails(int machineId)
        {
            var url = QueryHelpers.AddQueryString("/ExcavatorBucketDetails", new Dictionary<string,string?>
            {
                { "IdMachine", machineId.ToString() }
            });
            navigationManager.NavigateTo(url);
        }

    }

}
