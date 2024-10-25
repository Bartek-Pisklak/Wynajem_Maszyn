using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.ExcavatorAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;


namespace WynajemMaszyn.Application.Features.Excavators.Command.DeleteExcavators
{
    public class DeleteExcavatorCommandHandler : IRequestHandler<DeleteExcavatorCommand, ErrorOr<ExcavatorResponse>>
    {
        private readonly IExcavatorRepository _excavatorRepository;
        private readonly IUserContextGetIdService _userContextGetId;
        private readonly IMachineryRepository _machineryRepository;

        public DeleteExcavatorCommandHandler(IExcavatorRepository excavatorRepository, 
            IUserContextGetIdService userContextGetId,
            IMachineryRepository machineryRepository)
        {
            _excavatorRepository = excavatorRepository;
            _userContextGetId = userContextGetId;
            _machineryRepository=machineryRepository;   
        }

        public async Task<ErrorOr<ExcavatorResponse>> Handle(DeleteExcavatorCommand request, CancellationToken cancellationToken)
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
            await _excavatorRepository.DeleteExcavator(id);
            await _machineryRepository.DeleteMachinery(machinery);
            return new ExcavatorResponse("Task delete");
        }
    }
}
