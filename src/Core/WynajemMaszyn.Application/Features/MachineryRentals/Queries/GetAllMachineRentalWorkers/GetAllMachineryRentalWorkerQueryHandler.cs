using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Features.MachineryRentals.Queries.DTOs;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.Common.Errors;

namespace WynajemMaszyn.Application.Features.MachineryRentals.Queries.GetAllMachineRentalWorkers
{
    public class GetAllMachineryRentalWorkerQueryHandler : IRequestHandler<GetAllMachineryRentalWorkerQuery, ErrorOr<List<GetAllMachineryRentalDto>>>
    {
        private readonly IMachineryRentalRepository _machineryRentalRepository;
        private readonly ICurrentUserService _currentUserService;

        public GetAllMachineryRentalWorkerQueryHandler(
            IMachineryRentalRepository machineryRentalRepository, 
            ICurrentUserService currentUserService)
        {
            _machineryRentalRepository=machineryRentalRepository;
            _currentUserService=currentUserService;
        }

        public async Task<ErrorOr<List<GetAllMachineryRentalDto>>> Handle(GetAllMachineryRentalWorkerQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var roles = _currentUserService.Roles;

            if (string.IsNullOrEmpty(userId) || !roles.Contains("Worker"))
            {
                return Errors.MachineRental.UserDoesNotLogged;
            }


            var machineryRental = await _machineryRentalRepository.GetAllMachineryRentalWorker();



            List<GetAllMachineryRentalDto> machineryRentalWorker = machineryRental.Select(x => new GetAllMachineryRentalDto
            {
                Id = x.Id,
                Cost = x.Cost,
                BeginRent = x.BeginRent,
                EndRent = x.EndRent,
                RentalStatus = x.RentalStatus,
                PaymentStatus = x.PaymentStatus,
                IsReturned = x.IsReturned

            }).ToList();


            return machineryRentalWorker;
        }
    }






/*    public int Id { get; set; }
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
    public bool IsReturned { get; set; } = false;*/
}
