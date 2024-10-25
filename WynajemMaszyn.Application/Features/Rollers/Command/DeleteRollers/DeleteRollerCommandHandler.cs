using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.ExcavatorAnswer;
using WynajemMaszyn.Application.Contracts.HarversterAnswer;
using WynajemMaszyn.Application.Contracts.RollerAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Features.Rollers.Command.DeleteRollers
{
    public class DeleteRollerCommandHandler : IRequestHandler<DeleteRollerCommand, ErrorOr<RollerResponse>>
    {
        private readonly IRollerRepository _rollerRepository;
        private readonly IUserContextGetIdService _userContextGetId;
        private readonly IMachineryRepository _machineryRepository;

        public DeleteRollerCommandHandler(IRollerRepository rollerRepository,
                                            IUserContextGetIdService userContextGetId,
                                            IMachineryRepository machineryRepository)
        {
            _rollerRepository = rollerRepository;
            _userContextGetId = userContextGetId;
            _machineryRepository = machineryRepository;
        }

        public async Task<ErrorOr<RollerResponse>> Handle(DeleteRollerCommand request, CancellationToken cancellationToken)
        {

            var userId = 1;//_userContextGetId.GetUserId;

            /*            if (userId is null)
                        {
                            return Errors.WorkTask.UserDoesNotLogged;
                        }*/



            int id = request.Id;
            var machinery = new Machinery
            {
                ExcavatorId = id
            };
            await _rollerRepository.DeleteRoller(id);
            await _machineryRepository.DeleteMachinery(machinery);
            return new RollerResponse("Roller delete");
        }
    }
}
