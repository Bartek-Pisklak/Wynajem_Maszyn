using MediatR;
using ErrorOr;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Contracts.ExcavatorAnswer;
using WynajemMaszyn.Application.Common.Errors;
using Microsoft.AspNetCore.Identity;


namespace WynajemMaszyn.Application.Features.Excavators.Command.CreateExcavators
{
    public class CreateExcavatorCommandHandler : IRequestHandler<CreateExcavatorCommand, ErrorOr<ExcavatorResponse>>
    {
        private readonly IExcavatorRepository _excavatorRepository;
        private readonly IMachineryRepository _machineryRepository;
        private readonly ICurrentUserService _currentUserService;


        public CreateExcavatorCommandHandler(IExcavatorRepository excavatorRepository,
            IMachineryRepository machineryRepository,
            ICurrentUserService currentUserService)
        {
            _excavatorRepository = excavatorRepository;
            _machineryRepository = machineryRepository;
            _currentUserService=currentUserService;
        }

        public async Task<ErrorOr<ExcavatorResponse>> Handle(CreateExcavatorCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var roles = _currentUserService.Roles;

            if (string.IsNullOrEmpty(userId) || !roles.Contains("Worker"))
            {
                return Errors.ExcavatorBucket.UserDoesNotLogged;
            }


            var excavator = new Excavator
            {
                UserId = userId,
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
                ImagePath = request.ImagePath,
                Description = request.Description
        };


            int idNewMahine = await _excavatorRepository.CreateExcavator(excavator);
            var machine = new Machinery
            {
                Name= excavator.Name,
                ExcavatorId=idNewMahine
            };
            await _machineryRepository.CreateMachinery(machine);


            return new ExcavatorResponse("Excavator added");
        }
    }
}
