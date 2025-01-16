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
        private readonly UserManager<User> _userManager;
        private readonly IMachineryRepository _machineryRepository;

        public CreateRollerCommandHandler(IRollerRepository rollerRepository,
                                            UserManager<User> userManager,
                                            IMachineryRepository machineryRepository)
        {
            _rollerRepository = rollerRepository;
            _userManager = userManager;
            _machineryRepository = machineryRepository;
        }

        public async Task<ErrorOr<RollerResponse>> Handle(CreateRollerCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(request.context.User);
            var roleUser = await _userManager.GetRolesAsync(user);


            if (user.Id is null && roleUser.Contains("Worker"))
            {
                return Errors.ExcavatorBucket.UserDoesNotLogged;
            }

            var roller = new Roller
            {
                UserId = user.Id,
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
