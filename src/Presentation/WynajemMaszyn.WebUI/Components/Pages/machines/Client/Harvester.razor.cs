using Microsoft.AspNetCore.WebUtilities;
using WynajemMaszyn.Application.Features.Excavators.Queries.DTOs;
using WynajemMaszyn.Application.Features.Harvesters.Queries.DTOs;
using WynajemMaszyn.Application.Features.Harvesters.Queries.GetAllHarvesters;

namespace WynajemMaszyn.WebUI.Components.Pages.machines.Client
{
    partial class Harvester
    {

        private List<GetAllHarvesterDto>? harvester;

        private int? minYear, maxYear;
        private int? minPower, maxPower;
        private int? minSpeed, maxSpeed;
        private int? minWeight, maxWeight;
        private float? minPrice, maxPrice;
        private DateTime? startDate, endDate;
        private bool showInRepair = false;

        private List<GetAllHarvesterDto> filteredHarvesters = new();

        private void SearchMachines()
        {
            filteredHarvesters = harvester.Where(m =>
                (!minYear.HasValue || m.ProductionYear >= minYear) &&
                (!maxYear.HasValue || m.ProductionYear <= maxYear) &&
                (!minPower.HasValue || m.EnginePower >= minPower) &&
                (!maxPower.HasValue || m.EnginePower <= maxPower) &&
                (!minSpeed.HasValue || m.DrivingSpeed >= minSpeed) &&
                (!maxSpeed.HasValue || m.DrivingSpeed <= maxSpeed) &&
                (!minWeight.HasValue || m.Weight >= minWeight) &&
                (!maxWeight.HasValue || m.Weight <= maxWeight) &&
                (!minPrice.HasValue || m.RentalPricePerDay >= minPrice) &&
                (!maxPrice.HasValue || m.RentalPricePerDay <= maxPrice) &&
                (showInRepair || !m.IsRepair) &&
                (CheckAvailability(m, startDate, endDate))
            ).ToList();
        }

        private bool CheckAvailability(GetAllHarvesterDto machine, DateTime? start, DateTime? end)
        {
            if (!start.HasValue || !end.HasValue)
                return true;

            return !machine.DateBusyAll.Any(d =>
                d.HasValue && (
                    (start.Value >= d.Value.Start && start.Value <= d.Value.End) ||
                    (end.Value >= d.Value.Start && end.Value <= d.Value.End) ||
                    (start.Value <= d.Value.Start && end.Value >= d.Value.End)
                )
            );
        }

        private void ResetSearchMachines()
        {
            filteredHarvesters = harvester;
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var query = new GetAllHarvesterQuery();
                var response = await Mediator.Send(query);


                harvester = response.Match(
                harvesterResponse =>
                {
                    return harvesterResponse;
                },
                errors =>
                {
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"Error: {error.Description} (Code: {error.Code})");
                    }

                    throw new Exception("Failed to retrieve harvesters.");
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
            filteredHarvesters = harvester;
        }



        private void NavigateToDetails(int machineId)
        {
            var url = QueryHelpers.AddQueryString("/HarvesterDetails", new Dictionary<string, string?>
            {
                { "IdMachine", machineId.ToString() }
            });
            navigationManager.NavigateTo(url);
        }


    }
}
