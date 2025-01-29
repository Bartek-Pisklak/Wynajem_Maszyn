using Microsoft.AspNetCore.WebUtilities;
using WynajemMaszyn.Application.Features.Excavators.Queries.DTOs;
using WynajemMaszyn.Application.Features.Excavators.Queries.GetAllExcavators;

namespace WynajemMaszyn.WebUI.Components.Pages.machines.Client
{
    partial class Excavator
    {
        private List<GetAllExcavatorDto>? excavator;

        private int? minYear, maxYear;
        private int? minPower, maxPower;
        private int? minSpeed, maxSpeed;
        private int? minWeight, maxWeight;
        private float? minPrice, maxPrice;
        private DateTime? startDate, endDate;
        private bool showInRepair = false; 

        private List<GetAllExcavatorDto> filteredExcavators = new();

        private void SearchMachines()
        {
            filteredExcavators = excavator.Where(m =>
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

        private bool CheckAvailability(GetAllExcavatorDto machine, DateTime? start, DateTime? end)
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
            filteredExcavators = excavator;
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var query = new GetAllExcavatorQuery();
                var response = await Mediator.Send(query);

                excavator = response.Match(
                excavatorResponse =>
                {
                    return excavatorResponse;
                },
                errors =>
                {
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"Error: {error.Description} (Code: {error.Code})");
                    }
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

            filteredExcavators = excavator;
        }



        private void NavigateToDetails(int machineId)
        {
            var url = QueryHelpers.AddQueryString("/ExcavatorDetails", new Dictionary<string, string?>
            {
                { "IdMachine", machineId.ToString() }
            });
            navigationManager.NavigateTo(url);
        }
    }
}
