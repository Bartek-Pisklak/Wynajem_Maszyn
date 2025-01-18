using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.RollerAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;
using Microsoft.AspNetCore.Identity;

namespace WynajemMaszyn.Application.Features.Rollers.Command.CreateRollers
{
    public class CreateRollerCommandHandler : IRequestHandler<CreateRollerCommand, ErrorOr<RollerResponse>>
    {
        private readonly IRollerRepository _rollerRepository;
        private readonly IMachineryRepository _machineryRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreateRollerCommandHandler(IRollerRepository rollerRepository,
                                            IMachineryRepository machineryRepository,
                                            ICurrentUserService currentUserService)
        {
            _rollerRepository = rollerRepository;
            _machineryRepository = machineryRepository;
            _currentUserService=currentUserService;
        }

        public async Task<ErrorOr<RollerResponse>> Handle(CreateRollerCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var roles = _currentUserService.Roles;

            if (string.IsNullOrEmpty(userId) || !roles.Contains("Worker"))
            {
                return Errors.ExcavatorBucket.UserDoesNotLogged;
            }


            var roller = new Roller
            {
                UserId = userId,
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



            var idNewMahine = await _rollerRepository.CreateRoller(roller);
            var machinery = new Machinery
            {
                RollerId = idNewMahine,
                Name = roller.Name,
            };
            await _machineryRepository.CreateMachinery(machinery);
            return new RollerResponse("Roller added");
        }
    }
}
