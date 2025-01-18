using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.RollerAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WynajemMaszyn.Application.Features.Rollers.Command.DeleteRollers
{
    public class DeleteRollerCommandHandler : IRequestHandler<DeleteRollerCommand, ErrorOr<RollerResponse>>
    {
        private readonly IRollerRepository _rollerRepository;
        private readonly IMachineryRepository _machineryRepository;
        private readonly ICurrentUserService _currentUserService;

        public DeleteRollerCommandHandler(IRollerRepository rollerRepository,
                                            IMachineryRepository machineryRepository,
                                            ICurrentUserService currentUserService)
        {
            _rollerRepository = rollerRepository;
            _machineryRepository = machineryRepository;
            _currentUserService=currentUserService;
        }

        public async Task<ErrorOr<RollerResponse>> Handle(DeleteRollerCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var roles = _currentUserService.Roles;

            if (string.IsNullOrEmpty(userId) || !roles.Contains("Worker"))
            {
                return Errors.ExcavatorBucket.UserDoesNotLogged;
            }


            var machinery = new Machinery
            {
                ExcavatorId = request.Id
            };
            await _machineryRepository.DeleteMachinery(machinery);
            await _rollerRepository.DeleteRoller(request.Id);
            return new RollerResponse("Roller delete");
        }
    }
}
