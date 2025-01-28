using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.Features.MachineryRentals.Queries.DTOs
{
    public class GetAllMachineryRentalDto
    {
        public int Id { get; set; }
        public float Cost { get; set; }
        public DateTime BeginRent { get; set; } = DateTime.Today.ToUniversalTime();
        public DateTime EndRent { get; set; } = DateTime.Today.ToUniversalTime();
        public RentalStatus RentalStatus { get; set; } = RentalStatus.koszyk;
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.oczekuje;
        public bool IsReturned { get; set; } = false;
    }
}
