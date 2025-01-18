using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.ExcavatorAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;
using Microsoft.AspNetCore.Identity;

namespace WynajemMaszyn.Application.Features.Excavators.Command.DeleteExcavators
{
    public class DeleteExcavatorCommandHandler : IRequestHandler<DeleteExcavatorCommand, ErrorOr<ExcavatorResponse>>
    {
        private readonly IExcavatorRepository _excavatorRepository;
        private readonly IMachineryRepository _machineryRepository;
        private readonly ICurrentUserService _currentUserService;

        public DeleteExcavatorCommandHandler(IExcavatorRepository excavatorRepository, 
            IMachineryRepository machineryRepository,
            ICurrentUserService currentUserService)
        {
            _excavatorRepository = excavatorRepository;
            _machineryRepository = machineryRepository;  
            _currentUserService = currentUserService;
        }

        public async Task<ErrorOr<ExcavatorResponse>> Handle(DeleteExcavatorCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var roles = _currentUserService.Roles;

            if (string.IsNullOrEmpty(userId) || !roles.Contains("Worker"))
            {
                return Errors.ExcavatorBucket.UserDoesNotLogged;
            }

            var machinery = new Machinery
            {
                ExcavatorId= request.Id
            };
            await _machineryRepository.DeleteMachinery(machinery);
            await _excavatorRepository.DeleteExcavator(request.Id);

            return new ExcavatorResponse("Task delete");
        }
    }
}
