using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.Features.Enums
{
    public partial class EnumsCustomer
    {
        public List<string> GetPaymentStatus()
        {
            List<string> chassisValues = Enum.GetValues(typeof(PaymentStatus))
                                 .Cast<PaymentStatus>()
                                 .Select(c => c.ToString())
                                 .ToList();
            return chassisValues;
        }
        public List<string> GetRentalStatus()
        {
            List<string> chassisValues = Enum.GetValues(typeof(RentalStatus))
                                 .Cast<RentalStatus>()
                                 .Select(c => c.ToString())
                                 .ToList();
            return chassisValues;
        }
    }
}
