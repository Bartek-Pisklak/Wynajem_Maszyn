using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.MachineryRentalAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;


namespace WynajemMaszyn.Application.Features.MachineryRentals.Command.CreateMachineRentals
{
    public class CreateMachineRentalCommandHandler : IRequestHandler<CreateMachineRentalCommand, ErrorOr<MachineryRentalResponse>>
    {
        private readonly IMachineryRentalRepository _machineryRentalRepository;
        private readonly IUserContextGetIdService _userContextGetId;


        public CreateMachineRentalCommandHandler(
            IMachineryRentalRepository machineryRentalRepository,
            IUserContextGetIdService userContextGetIdService
            )
        {
            _machineryRentalRepository = machineryRentalRepository;
            _userContextGetId = userContextGetIdService;
        }

        public async Task<ErrorOr<MachineryRentalResponse>> Handle(CreateMachineRentalCommand request, CancellationToken cancellationToken)
        {
            var userId = _userContextGetId.GetUserId;

            if (userId is null)
            {
                return Errors.MachineRental.UserDoesNotLogged;
            }
            var machineryRent = new MachineryRental
            {

            };



            await _machineryRentalRepository.CreateMachineryRental(machineryRent);

            return new MachineryRentalResponse("Order created");
        }
    }
}
