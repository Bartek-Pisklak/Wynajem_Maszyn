using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.MachineryRentalAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;
using WynajemMaszyn.Domain.Enums;


namespace WynajemMaszyn.Application.Features.MachineryRentals.Command.CreateMachineRentals
{
    public class CreateMachineRentalCommandHandler : IRequestHandler<CreateMachineRentalCommand, ErrorOr<MachineryRentalResponse>>
    {
        private readonly IMachineryRentalRepository _machineryRentalRepository;
        private readonly ICurrentUserService _currentUserService;


        public CreateMachineRentalCommandHandler(
            IMachineryRentalRepository machineryRentalRepository,
            ICurrentUserService currentUserService
            )
        {
            _machineryRentalRepository = machineryRentalRepository;
            _currentUserService = currentUserService;
        }

        public async Task<ErrorOr<MachineryRentalResponse>> Handle(CreateMachineRentalCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var roles = _currentUserService.Roles;


            if (string.IsNullOrEmpty(userId))
            {
                return Errors.MachineRental.UserDoesNotLogged;
            }

            int IdCard = await _machineryRentalRepository.GetIdCardUser(userId);

            var machineryRentalDetails = await _machineryRentalRepository.GetMachineryRental(IdCard);
            int days = (request.End - request.Start).Days;


            var machineryRent = new MachineryRental
            {
                Id = IdCard,
                UserId = userId,
                RentalStatus = RentalStatus.oczekuje,
                PaymentMethod = request.PaymentMetod,
                Cost = machineryRentalDetails.Cost * days,
                Deposit = machineryRentalDetails.Cost * days,
                BeginRent = request.Start.ToUniversalTime(),
                EndRent = request.End.ToUniversalTime(),
            };




            await _machineryRentalRepository.CreateRental(machineryRent);

            return new MachineryRentalResponse("Order created");
        }
    }
}
