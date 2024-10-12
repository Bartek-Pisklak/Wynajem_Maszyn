using ErrorOr;
using MediatR;
using System.Runtime.InteropServices;
using WynajemMaszyn.Application.Contracts.ExcavatorAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Features.Excavators.Command.EditExcavators
{
    public class EditExcavatorCommandHandler : IRequestHandler<EditExcavatorCommand, ErrorOr<ExcavatorResponse>>
    {
        private readonly IExcavatorRepository _excavatorRepository;
        private readonly IUserContextGetIdService _userContextGetId;
        private readonly IMachineryRepository _machineryRepository;

        public EditExcavatorCommandHandler(IExcavatorRepository excavatorRepository,
            IUserContextGetIdService userContextGetId,
            IMachineryRepository machineryRepository)
        {
            _excavatorRepository = excavatorRepository;
            _userContextGetId = userContextGetId;
            _machineryRepository = machineryRepository;
        }

        public async  Task<ErrorOr<ExcavatorResponse>> Handle(EditExcavatorCommand request, CancellationToken cancellationToken)
        {
            var userId = 1;//_userContextGetId.GetUserId;

            /*            if (userId is null)
                        {
                            return Errors.WorkTask.UserDoesNotLogged;
                        }*/

            var excavator = new Excavator
            {
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
                Description = request.Description
            };

            var machine = new Machinery
            {
                Name= request.Name
            };

            await _excavatorRepository.EditExcavator(request.Id, excavator);
            await _machineryRepository.EditMachinery(request.Id, machine);

            return new ExcavatorResponse("Excavator edited");
        }
    }
}