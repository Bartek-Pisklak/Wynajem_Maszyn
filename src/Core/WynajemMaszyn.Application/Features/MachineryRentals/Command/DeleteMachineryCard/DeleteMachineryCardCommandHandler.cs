using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.MachineryRentalAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;


namespace WynajemMaszyn.Application.Features.MachineryRentals.Command.DeleteMachineryCard
{
    public class DeleteMachineryCardCommandHandler : IRequestHandler<DeleteMachineryCardCommand, ErrorOr<MachineryRentalResponse>>
    {
        private readonly IMachineryRentalRepository _machineryRentalRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMachineryRepository _machineryRepository;


        public DeleteMachineryCardCommandHandler(IMachineryRentalRepository machineryRentalRepository,
                                    IMachineryRepository machineryRepository,
                                    ICurrentUserService currentUserService)
        {
            _machineryRentalRepository = machineryRentalRepository;
            _machineryRepository = machineryRepository;
            _currentUserService = currentUserService;
        }

        public async Task<ErrorOr<MachineryRentalResponse>> Handle(DeleteMachineryCardCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var roles = _currentUserService.Roles;

            if (string.IsNullOrEmpty(userId) || !roles.Contains("Client"))
            {
                return Errors.MachineRental.UserDoesNotLogged;
            }

            Machinery machinery = new Machinery();

            if (request.TypeMachine == "Excavatr")
            {
                machinery.ExcavatorId = request.IdMachine;
            }
            else if (request.TypeMachine == "ExcavatorBucket")
            {
                machinery.ExcavatorBucketId = request.IdMachine;
            }
            else if (request.TypeMachine == "Roller")
            {
                machinery.RollerId = request.IdMachine;
            }
            else if (request.TypeMachine == "Harvester")
            {
                machinery.HarvesterId = request.IdMachine;
            }
            else if (request.TypeMachine == "WoodChipper")
            {
                machinery.WoodChipperId = request.IdMachine;
            }


            await _machineryRentalRepository.DeleteMachineryIdToCart(machinery, userId);

            return new MachineryRentalResponse("delete machine from cart");
        }
    }
}
