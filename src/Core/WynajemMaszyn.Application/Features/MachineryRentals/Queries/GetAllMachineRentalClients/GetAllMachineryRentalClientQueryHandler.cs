using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Features.MachineryRentals.Queries.DTOs;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.Common.Errors;


namespace WynajemMaszyn.Application.Features.MachineryRentals.Queries.GetAllMachineRentals
{
    public class GetAllMachineryRentalClientQueryHandler : IRequestHandler<GetAllMachineryRentalClientQuery, ErrorOr<List<GetAllMachineryRentalDto>>>
    {
        private readonly IMachineryRentalRepository _machineryRentalRepository;
        private readonly ICurrentUserService _currentUserService;

        public GetAllMachineryRentalClientQueryHandler(
            IMachineryRentalRepository machineryRentalRepository,
            ICurrentUserService currentUserService)
        {
            _machineryRentalRepository = machineryRentalRepository;
            _currentUserService = currentUserService;
        }

        public async Task<ErrorOr<List<GetAllMachineryRentalDto>>> Handle(GetAllMachineryRentalClientQuery request, CancellationToken cancellationToken)
        {

            var userId = _currentUserService.UserId;
            var roles = _currentUserService.Roles;

            if (string.IsNullOrEmpty(userId) || !roles.Contains("Client"))
            {
                return Errors.MachineRental.UserDoesNotLogged;
            }


            var machineryRental = await _machineryRentalRepository.GetAllMachineryRentalUser(userId);



            List<GetAllMachineryRentalDto> machineryRentalClient = machineryRental.Select(x => new GetAllMachineryRentalDto
            {
                Id = x.Id,
                Cost = x.Cost,
                BeginRent = x.BeginRent,
                EndRent = x.EndRent,
                RentalStatus = x.RentalStatus,
                PaymentStatus = x.PaymentStatus,
                IsReturned = x.IsReturned

            }).ToList();


            return machineryRentalClient;
        }
    }
}