using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.Features.MachineryRentals.Queries.DTOs
{
    public class GetMachineryRentalDto
    {
        public float Cost { get; set; } = 0;
        public DateTime BeginRent { get; set; } = DateTime.Today.ToUniversalTime();
        public DateTime EndRent { get; set; } = DateTime.Today.ToUniversalTime();
        public RentalStatus RentalStatus { get; set; } = RentalStatus.koszyk;
        public float? Deposit { get; set; }
        public float? LateFee { get; set; }
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.oczekuje;
        public string? Facture { get; set; }
        public string? Contract { get; set; }
        public string? PaymentMethod { get; set; }
        public string? AdditionalNotes { get; set; }
        public bool IsReturned { get; set; } = false;

        public List<GetMachineDto> MachineryInCard { get; set; }
    }
}
