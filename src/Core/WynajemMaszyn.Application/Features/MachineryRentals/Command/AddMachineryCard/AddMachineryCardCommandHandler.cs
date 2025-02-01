using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.MachineryRentalAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;

namespace WynajemMaszyn.Application.Features.MachineryRentals.Command.AddMachineryCard
{
    public class AddMachineryCardCommandHandler : IRequestHandler<AddMachineryCardCommand, ErrorOr<MachineryRentalResponse>>
    {
        private readonly IMachineryRentalRepository _machineryRentalRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMachineryRepository _machineryRepository;


        public AddMachineryCardCommandHandler( IMachineryRentalRepository machineryRentalRepository, 
                                    IMachineryRepository machineryRepository,
                                    ICurrentUserService currentUserService)
        {
            _machineryRentalRepository = machineryRentalRepository;
            _machineryRepository = machineryRepository;
            _currentUserService = currentUserService;
        }

        public async Task<ErrorOr<MachineryRentalResponse>> Handle(AddMachineryCardCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var roles = _currentUserService.Roles;

            if (string.IsNullOrEmpty(userId) || !roles.Contains("Client"))
            {
                return Errors.MachineRental.UserDoesNotLogged;
            }

            Machinery machinery = new Machinery();
            
            if(request.TypeMachine == "Excavator")
            {
                machinery.ExcavatorId = request.IdMachine;
            }
            else if( request.TypeMachine == "ExcavatorBucket")
            {
                machinery.ExcavatorBucketId = request.IdMachine;
            }
            else if (request.TypeMachine == "Roller")
            {
                machinery.RollerId = request.IdMachine;
            }
            else if( request.TypeMachine == "Harvester")
            {
                machinery.HarvesterId = request.IdMachine;
            }
            else if (request.TypeMachine == "WoodChipper")
            {
                machinery.WoodChipperId = request.IdMachine;
            }


            await _machineryRentalRepository.AddMachineryIdToCart(machinery, userId);

            return new MachineryRentalResponse("added machine to cart");
        }
    }
}
