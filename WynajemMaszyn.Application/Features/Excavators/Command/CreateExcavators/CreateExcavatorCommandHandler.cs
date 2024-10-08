using MediatR;
using ErrorOr;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Contracts.ExcavatorAnswer;

namespace WynajemMaszyn.Application.Features.Excavators.Command.CreateExcavators
{
    public class CreateExcavatorCommandHandler : IRequestHandler<CreateExcavatorCommand, ErrorOr<ExcavatorResponse>>
    {
        private readonly IExcavatorRepository _excavatorRepository;
        private readonly IUserContextGetIdService _userContextGetId;

        public CreateExcavatorCommandHandler(IExcavatorRepository excavatorRepository, IUserContextGetIdService userContextGetId)
        {
            _excavatorRepository = excavatorRepository;
            _userContextGetId = userContextGetId;
        }

        public async Task<ErrorOr<ExcavatorResponse>> Handle(CreateExcavatorCommand request, CancellationToken cancellationToken)
        {
            var userId = 1;//_userContextGetId.GetUserId;

            /*            if (userId is null)
                        {
                            return Errors.WorkTask.UserDoesNotLogged;
                        }*/

            var excavator = new Excavator
            {
                IdUser = (int)userId,
                Name = request.Name,
                Description = request.Description
            };

            int idMachine = await _excavatorRepository.CreateExcavator(excavator);



            return new ExcavatorResponse("Excavator added");
        }
    }
}
