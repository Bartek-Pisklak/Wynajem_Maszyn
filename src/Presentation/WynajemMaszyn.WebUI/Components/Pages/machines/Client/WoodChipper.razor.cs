using Microsoft.AspNetCore.WebUtilities;
using WynajemMaszyn.Application.Features.Harvesters.Queries.DTOs;
using WynajemMaszyn.Application.Features.WoodChippers.Queries.DTOs;
using WynajemMaszyn.Application.Features.WoodChippers.Queries.GetAllWoodChippers;

namespace WynajemMaszyn.WebUI.Components.Pages.machines.Client
{
    partial class WoodChipper
    {
        private List<GetAllWoodChipperDto>? woodChipper;

        private int? minYear, maxYear;
        private int? minPower, maxPower;
        private int? minSpeed, maxSpeed;
        private int? minWeight, maxWeight;
        private float? minPrice, maxPrice;
        private DateTime? startDate, endDate;
        private bool showInRepair = false;

        private List<GetAllWoodChipperDto> filteredWoodChippers = new();

        private void SearchMachines()
        {
            filteredWoodChippers = woodChipper.Where(m =>
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

        private bool CheckAvailability(GetAllWoodChipperDto machine, DateTime? start, DateTime? end)
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
            filteredWoodChippers = woodChipper;
        }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                var query = new GetAllWoodChipperQuery();
                var response = await Mediator.Send(query);

                woodChipper = response.Match(
                woodChipperResponse =>
                {
                    return woodChipperResponse;
                },
                errors =>
                {
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"Error: {error.Description} (Code: {error.Code})");
                    }

                    throw new Exception("Failed to retrieve woodchipper.");
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
            filteredWoodChippers = woodChipper;
        }


        private void NavigateToDetails(int machineId)
        {
            var url = QueryHelpers.AddQueryString("/WoodChipperDetails", new Dictionary<string, string?>
            {
                { "IdMachine", machineId.ToString() }
            });
            navigationManager.NavigateTo(url);
        }
    }
}
