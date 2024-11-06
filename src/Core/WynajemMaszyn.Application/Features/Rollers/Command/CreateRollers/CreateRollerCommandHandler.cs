using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.RollerAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;

namespace WynajemMaszyn.Application.Features.Rollers.Command.CreateRollers
{
    public class CreateRollerCommandHandler : IRequestHandler<CreateRollerCommand, ErrorOr<RollerResponse>>
    {
        private readonly IRollerRepository _rollerRepository;
        private readonly IUserContextGetIdService _userContextGetId;
        private readonly IMachineryRepository _machineryRepository;

        public CreateRollerCommandHandler(IRollerRepository rollerRepository,
                                            IUserContextGetIdService userContextGetId,
                                            IMachineryRepository machineryRepository)
        {
            _rollerRepository = rollerRepository;
            _userContextGetId = userContextGetId;
            _machineryRepository = machineryRepository;
        }

        public async Task<ErrorOr<RollerResponse>> Handle(CreateRollerCommand request, CancellationToken cancellationToken)
        {
            var userId = _userContextGetId.GetUserId;

            if (userId is null)
            {
                return Errors.Roller.UserDoesNotLogged;
            }

            var roller = new Roller
            {
                UserId = (int)userId,
                Name = request.Name,
                ProductionYear = request.ProductionYear,
                OperatingHours = request.OperatingHours,
                Weight = request.Weight,
                Engine = request.Engine,
                EnginePower = request.EnginePower,
                DrivingSpeed = request.DrivingSpeed,
                FuelConsumption = request.FuelConsumption,
                FuelType = request.FuelType,
                Gearbox = request.Gearbox,
                NumberOfDrums = request.NumberOfDrums,
                RollerType = request.RollerType,
                DrumWidth = request.DrumWidth,
                MaxCompactionForce = request.MaxCompactionForce,
                IsVibratory = request.IsVibratory,
                KnigeAsfalt = request.KnigeAsfalt,
                RentalPricePerDay = request.RentalPricePerDay,
                ImagePath = request.ImagePath,
                Description = request.Description
            };

            var machinery = new Machinery
            {
                RollerId = roller.Id,
                Name = roller.Name,
            };

            await _rollerRepository.CreateRoller(roller);
            await _machineryRepository.CreateMachinery(machinery);
            return new RollerResponse("Roller added");
        }
    }
}
