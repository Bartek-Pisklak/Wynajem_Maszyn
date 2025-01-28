using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.MachineryRentalAnswer;
using WynajemMaszyn.Application.Persistance;



namespace WynajemMaszyn.Application.Features.MachineryRentals.Command.EditMachineRentals
{
    public class EditMachineryRentalCommandHandler : IRequestHandler<EditMachineryRentalCommand, ErrorOr<MachineryRentalResponse>>
    {
        private readonly IMachineryRentalRepository _machineryRentalRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMachineryRepository _machineryRepository;

        public EditMachineryRentalCommandHandler(
            IMachineryRentalRepository machineryRentalRepository,
            IMachineryRepository machineryRepository,
            ICurrentUserService currentUserService)
        {
            _machineryRentalRepository = machineryRentalRepository;
            _machineryRepository = machineryRepository;
            _currentUserService = currentUserService;
        }

        public async Task<ErrorOr<MachineryRentalResponse>> Handle(EditMachineryRentalCommand request, CancellationToken cancellationToken)
        {





            return new MachineryRentalResponse("edited card to shopping");
        }
    }
}
