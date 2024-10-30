using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.HarversterAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Features.Harvesters.Command.DeleteHarvesters
{
    public class DeleteHarvesterCommandHandler : IRequestHandler<DeleteHarvesterCommand, ErrorOr<HarvesterResponse>>
    {
        private readonly IHarvesterRepository _harvesterRepository;
        private readonly IUserContextGetIdService _userContextGetId;
        private readonly IMachineryRepository _machineryRepository;

        public DeleteHarvesterCommandHandler(IHarvesterRepository harvesterRepository,
                                            IUserContextGetIdService userContextGetId,
                                            IMachineryRepository machineryRepository)
        {
            _harvesterRepository = harvesterRepository;
            _userContextGetId = userContextGetId;
            _machineryRepository = machineryRepository;
        }

        public async Task<ErrorOr<HarvesterResponse>> Handle(DeleteHarvesterCommand request, CancellationToken cancellationToken)
        {
            var userId = 1;//_userContextGetId.GetUserId;

            /*            if (userId is null)
                        {
                            return Errors.WorkTask.UserDoesNotLogged;
                        }*/



            int id = request.Id;
            var machinery = new Machinery
            {
                ExcavatorId= id
            };
            await _harvesterRepository.DeleteHarvester(id);
            await _machineryRepository.DeleteMachinery(machinery);
            return new HarvesterResponse("Harvester delete");
        }
    }
}
