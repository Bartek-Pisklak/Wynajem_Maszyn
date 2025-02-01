

using System.Security.Cryptography.X509Certificates;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Features.MachineryRentals.Queries.DTOs
{
    public class GetMachineDto
    {
        public Machinery Machine { get; set; }
        public string Name { get; set; }
        public float RentalPricePerDay { get; set; }
        public string ImagePath { get; set; }
    }
}
