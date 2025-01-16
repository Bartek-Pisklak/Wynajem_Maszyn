using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.ExcavatorAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;
using Microsoft.AspNetCore.Identity;


namespace WynajemMaszyn.Application.Features.Excavators.Command.EditExcavators
{
    public class EditExcavatorCommandHandler : IRequestHandler<EditExcavatorCommand, ErrorOr<ExcavatorResponse>>
    {
        private readonly IExcavatorRepository _excavatorRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMachineryRepository _machineryRepository;

        public EditExcavatorCommandHandler(IExcavatorRepository excavatorRepository,
            UserManager<User> userManager,
            IMachineryRepository machineryRepository)
        {
            _excavatorRepository = excavatorRepository;
            _userManager = userManager;
            _machineryRepository = machineryRepository;
        }

        public async  Task<ErrorOr<ExcavatorResponse>> Handle(EditExcavatorCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(request.context.User);
            var roleUser = await _userManager.GetRolesAsync(user);


            if (user.Id is null && roleUser.Contains("Worker"))
            {
                return Errors.ExcavatorBucket.UserDoesNotLogged;
            }

            var excavator = new Excavator
            {
                UserId = user.Id,
                Name = request.Name,
                TypeExcavator = request.TypeExcavator,
                TypeChassis = request.TypeChassis,
                RentalPricePerDay = request.RentalPricePerDay,
                ProductionYear = request.ProductionYear,
                OperatingHours = request.OperatingHours,
                Weight = request.Weight,
                Engine = request.Engine,
                EnginePower = request.EnginePower,
                DrivingSpeed = request.DrivingSpeed,
                FuelConsumption = request.FuelConsumption,
                FuelType = request.FuelType,
                Gearbox = request.Gearbox,
                MaxDiggingDepth = request.MaxDiggingDepth,
                Description = request.Description,
                IsRepair = request.IsRepair,
            };

            var machine = new Machinery
            {
                ExcavatorId=request.Id,
                Name= request.Name
            };

            await _excavatorRepository.EditExcavator(request.Id, excavator);
            await _machineryRepository.EditMachinery(machine);

            return new ExcavatorResponse("Excavator edited");
        }
    }
}