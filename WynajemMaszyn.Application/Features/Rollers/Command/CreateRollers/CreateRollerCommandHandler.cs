using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.RollerAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Features.Rollers.Command.CreateRollers
{
    public class CreateRollerCommandHandler : IRequestHandler<CreateRollerCommand, ErrorOr<RollerResponse>>
    {
        private readonly IRollerRepository _rollerRepository;
        private readonly IUserContextGetIdService _userContextGetId;

        public CreateRollerCommandHandler(IRollerRepository rollerRepository, IUserContextGetIdService userContextGetId) 
        {
            _rollerRepository = rollerRepository;
            _userContextGetId = userContextGetId;
        }

        public async Task<ErrorOr<RollerResponse>> Handle(CreateRollerCommand request, CancellationToken cancellationToken)
        {
            var userId = 1;//_userContextGetId.GetUserId;

            /*            if (userId is null)
                        {
                            return Errors.WorkTask.UserDoesNotLogged;
                        }*/

            var roller = new Roller
            {
                IdUser = (int)userId,
                Name = request.Name,
                Description = request.Description
            };

            await _rollerRepository.CreateRoller(roller);

            return new RollerResponse("Roller added");
        }
    }
}
