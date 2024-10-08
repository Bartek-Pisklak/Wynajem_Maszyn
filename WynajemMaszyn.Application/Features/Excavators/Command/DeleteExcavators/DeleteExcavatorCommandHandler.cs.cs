using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.ExcavatorAnswer;
using WynajemMaszyn.Application.Persistance;


namespace WynajemMaszyn.Application.Features.Excavators.Command.DeleteExcavators
{
    public class DeleteExcavatorCommandHandler : IRequestHandler<DeleteExcavatorCommand, ErrorOr<ExcavatorResponse>>
    {
        private readonly IExcavatorRepository _excavatorRepository;
        private readonly IUserContextGetIdService _userContextGetId;

        public DeleteExcavatorCommandHandler(IExcavatorRepository excavatorRepository, IUserContextGetIdService userContextGetId)
        {
            _excavatorRepository = excavatorRepository;
            _userContextGetId = userContextGetId;
        }

        public async Task<ErrorOr<ExcavatorResponse>> Handle(DeleteExcavatorCommand request, CancellationToken cancellationToken)
        {
            var userId = 1;//_userContextGetId.GetUserId;

            /*            if (userId is null)
                        {
                            return Errors.WorkTask.UserDoesNotLogged;
                        }*/
            int id = request.Id;
            await _excavatorRepository.DeleteExcavator(id);

            return new ExcavatorResponse("Task delete");
        }
    }
}
