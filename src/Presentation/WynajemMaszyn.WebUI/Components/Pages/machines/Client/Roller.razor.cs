using Microsoft.AspNetCore.WebUtilities;
using System.Reflection.PortableExecutable;
using WynajemMaszyn.Application.Features.Harvesters.Queries.DTOs;
using WynajemMaszyn.Application.Features.Rollers.Queries.DTOs;
using WynajemMaszyn.Application.Features.Rollers.Queries.GetAllRollers;

namespace WynajemMaszyn.WebUI.Components.Pages.machines.Client
{
    partial class Roller
    {

        private List<GetAllRollerDto>? roller;

        private int? minYear, maxYear;
        private int? minPower, maxPower;
        private int? minSpeed, maxSpeed;
        private int? minWeight, maxWeight;
        private float? minPrice, maxPrice;
        private DateTime? startDate, endDate;
        private bool showInRepair = false;

        private List<GetAllRollerDto> filteredRollers = new();

        private void SearchMachines()
        {
            filteredRollers = roller.Where(m =>
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

        private bool CheckAvailability(GetAllRollerDto machine, DateTime? start, DateTime? end)
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
            filteredRollers = roller;
        }

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
            filteredRollers = roller;
        }


        private void NavigateToDetails(int machineId)
        {
            var url = QueryHelpers.AddQueryString("/RollerDetails", new Dictionary<string, string?>
            {
                { "IdMachine", machineId.ToString() }
            });
            navigationManager.NavigateTo(url);
        }
    }
}
