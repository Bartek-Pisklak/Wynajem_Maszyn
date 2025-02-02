﻿


using WynajemMaszyn.Application.Features.Enums;
using WynajemMaszyn.Application.Features.MachineryRentals.Queries.DTOs;
using WynajemMaszyn.Application.Features.MachineryRentals.Queries.GetAllMachineRentalClients;

namespace WynajemMaszyn.WebUI.Components.Pages.Rental
{
    partial class MachineryRentalClientList
    {
        private List<string> StatusRental = new List<string>();
        private List<GetAllMachineryRentalDto> MachineryRentals = new List<GetAllMachineryRentalDto>();
        private string SelectedStatus = string.Empty;

        // Lista filtrowana w zależności od wybranego statusu
        private IEnumerable<GetAllMachineryRentalDto> FilteredRentals =>
            string.IsNullOrEmpty(SelectedStatus)
                ? MachineryRentals
                : MachineryRentals.Where(r => r.RentalStatus.ToString() == SelectedStatus);

        protected override async Task OnInitializedAsync()
        {
            EnumsCustomer enumsCustomer = new EnumsCustomer();
            StatusRental.Clear();
            StatusRental.AddRange(enumsCustomer.GetRentalStatus());

            var command = new GetAllMachineryRentalClientQuery();
            var response = await Mediator.Send(command);

            var machinery = response.Match(
            machineryResponse =>
            {
                return machineryResponse;
            },
            errors =>
            {
                foreach (var error in errors)
                {
                    Console.WriteLine($"Error: {error.Description} (Code: {error.Code})");
                }

                throw new Exception("Failed to retrieve list rental");
            });

            MachineryRentals = machinery;
        }

    }
}
