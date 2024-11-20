using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Domain.Entities
{
    public class MachineryRental
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public float Cost { get; set; }
        public DateTime BeginRent { get; set; }
        public DateTime EndRent { get; set; }

        public float? Deposit { get; set; }       
        public float? LateFee { get; set; }
        public RentalStatus RentalStatus {get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string Facture { get; set; }
        public string Contract { get; set; }
        public string PaymentMethod { get; set; }
        public string AdditionalNotes { get; set; }
        public bool IsReturned { get; set; } = false;

        public virtual User User { get; set; }
    }
}
