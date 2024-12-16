using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.RollerAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;

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

            var userId = _userContextGetId.GetUserId;

            if (userId is null)
            {
                return Errors.Roller.UserDoesNotLogged;
            }



            int id = request.Id;
            var machinery = new Machinery
            {
                ExcavatorId = id
            };
            await _machineryRepository.DeleteMachinery(machinery);
            await _rollerRepository.DeleteRoller(id);
            return new RollerResponse("Roller delete");
        }
    }
}
