using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.ExcavatorAnswer;
using WynajemMaszyn.Application.Contracts.RollerAnswer;
using WynajemMaszyn.Application.Persistance;

namespace WynajemMaszyn.Application.Features.Rollers.Command.EditRoller
{
    public class DeleteRollerCommandHandler : IRequestHandler<DeleteRollerCommand, ErrorOr<RollerResponse>>
    {
        private readonly IRollerRepository _rollerRepository;
        private readonly IUserContextGetIdService _userContextGetId;

        public DeleteRollerCommandHandler (IRollerRepository rollerRepository, IUserContextGetIdService userContextGetId)
        {
            _rollerRepository=rollerRepository;
            _userContextGetId=userContextGetId;
        }

        public async Task<ErrorOr<RollerResponse>> Handle(DeleteRollerCommand request, CancellationToken cancellationToken)
        {

            var userId = 1;//_userContextGetId.GetUserId;

            /*            if (userId is null)
                        {
                            return Errors.WorkTask.UserDoesNotLogged;
                        }*/
            int id = request.Id;
            await _rollerRepository.DeleteRoller(id);

            return new RollerResponse("Roller delete");



        }
    }
}
