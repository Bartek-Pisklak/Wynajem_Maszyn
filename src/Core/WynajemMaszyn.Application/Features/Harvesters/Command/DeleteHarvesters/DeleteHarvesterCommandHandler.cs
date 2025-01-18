using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.HarversterAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;
using Microsoft.AspNetCore.Identity;


namespace WynajemMaszyn.Application.Features.Harvesters.Command.DeleteHarvesters
{
    public class DeleteHarvesterCommandHandler : IRequestHandler<DeleteHarvesterCommand, ErrorOr<HarvesterResponse>>
    {
        private readonly IHarvesterRepository _harvesterRepository;
        private readonly IMachineryRepository _machineryRepository;
        private readonly ICurrentUserService _currentUserService;

        public DeleteHarvesterCommandHandler(IHarvesterRepository harvesterRepository,
                                            IMachineryRepository machineryRepository,
                                            ICurrentUserService currentUserService)
        {
            _harvesterRepository = harvesterRepository;
            _machineryRepository = machineryRepository;
            _currentUserService=currentUserService;
        }

        public async Task<ErrorOr<HarvesterResponse>> Handle(DeleteHarvesterCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var roles = _currentUserService.Roles;

            if (string.IsNullOrEmpty(userId) || !roles.Contains("Worker"))
            {
                return Errors.ExcavatorBucket.UserDoesNotLogged;
            }

            var machinery = new Machinery
            {
                HarvesterId= request.Id
            };
            await _machineryRepository.DeleteMachinery(machinery);
            await _harvesterRepository.DeleteHarvester(request.Id);

            return new HarvesterResponse("Harvester delete");
        }
    }
}
