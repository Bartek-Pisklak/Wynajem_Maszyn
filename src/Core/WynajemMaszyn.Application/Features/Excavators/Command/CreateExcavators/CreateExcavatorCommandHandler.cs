using MediatR;
using ErrorOr;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Contracts.ExcavatorAnswer;
using WynajemMaszyn.Application.Common.Errors;


namespace WynajemMaszyn.Application.Features.Excavators.Command.CreateExcavators
{
    public class CreateExcavatorCommandHandler : IRequestHandler<CreateExcavatorCommand, ErrorOr<ExcavatorResponse>>
    {
        private readonly IExcavatorRepository _excavatorRepository;
        private readonly IUserContextGetIdService _userContextGetId;
        private readonly IMachineryRepository _machineryRepository;



        public CreateExcavatorCommandHandler(IExcavatorRepository excavatorRepository,
            IUserContextGetIdService userContextGetId,
            IMachineryRepository machineryRepository)
        {
            _excavatorRepository = excavatorRepository;
            _userContextGetId = userContextGetId;
            _machineryRepository = machineryRepository;
        }

        public async Task<ErrorOr<ExcavatorResponse>> Handle(CreateExcavatorCommand request, CancellationToken cancellationToken)
        {
            var userId = _userContextGetId.GetUserId;

            if (userId is null)
            {
                return Errors.Excavator.UserDoesNotLogged;
            }

            var excavator = new Excavator
            {
                UserId = (int)userId,
                Name = request.Name,
                Type = request.Type,
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
                ImagePath=request.ImagePath,
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
