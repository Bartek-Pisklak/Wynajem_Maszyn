
using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Domain.Entities
{
    public class MachineryRental
    {
        public int Id { get; set; }
        public string UserId { get; set; }
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

        public virtual User User { get; set; }
    }
}
