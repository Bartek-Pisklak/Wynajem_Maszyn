using Microsoft.AspNetCore.Components;
using MudBlazor;
using WynajemMaszyn.Application.Features.MachineryRentals.Command.CreateMachineRentals;
using WynajemMaszyn.Application.Features.MachineryRentals.Queries.DTOs;
using WynajemMaszyn.Application.Features.MachineryRentals.Queries.GetMachineRentals;


namespace WynajemMaszyn.WebUI.Components.Pages.Rental
{
    partial class MachineryRentalCLientForm
    {
        private GetMachineryRentalDto Rental = new GetMachineryRentalDto();
        private bool _isSubmitted = false;

        private float CostTotal = 0;


        [Parameter]
        [SupplyParameterFromQuery]
        public int? IdCard { get; set; }
        private int DaysRented =>
                _dateRange.Start.HasValue && _dateRange.End.HasValue
                ? Math.Max(1, (_dateRange.End.Value - _dateRange.Start.Value).Days)
                : 0;

        private string CheckDate(DateTime date)
        {
            /* if (bucket.DateBusy is not null)
             {
                 foreach ((DateTime start, DateTime end) m in bucket.DateBusy)
                 {
                     if (m.start <= date && m.end >= date)
                     {
                         return "busy-day";
                     }
                 }
             }*/
            CostTotal= Rental.Cost * DaysRented;
            return string.Empty;
        }

        private MudDateRangePicker _picker;
        private DateRange _dateRange = new DateRange(DateTime.Today, DateTime.Now.AddDays(1).Date);

        private List<GetMachineDto> machines = new List<GetMachineDto>();



        private async void HandleValidSubmit()
        {
            AddMachineRental();

        }


        private async void AddMachineRental()
        {
            try
            {
                var command = new CreateMachineRentalCommand(
                    Rental.PaymentMethod,
                    (DateTime)_dateRange.Start,
                    (DateTime)_dateRange.End
                    );


                var response = await Mediator.Send(command);


                var newMachine = response.Match(
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

                    throw new Exception("Failed send card to system.");
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

            navigationManager.NavigateTo("/MachineryRentalClientForm", forceLoad: true);

        }

        protected override async Task OnInitializedAsync()
        {

            var query = new GetMachineryRentalQuery(IdCard);
            var response = await Mediator.Send(query);


            Rental = response.Match(
            machineResponse =>
            {
                // Zwraca listę koparek, jeśli żadne błędy nie wystąpiły
                return machineResponse;
            },
            errors =>
            {
                foreach (var error in errors)
                {
                    Console.WriteLine($"Error: {error.Description} (Code: {error.Code})");
                }


                throw new Exception("Failed card machine retrive");
            }
            );

            CostTotal= Rental.Cost;


        }
    }

}
