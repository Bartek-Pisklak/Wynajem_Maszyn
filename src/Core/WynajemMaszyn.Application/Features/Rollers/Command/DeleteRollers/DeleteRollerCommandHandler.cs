using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.RollerAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;
using Microsoft.AspNetCore.Identity;

namespace WynajemMaszyn.Application.Features.Rollers.Command.DeleteRollers
{
    public class DeleteRollerCommandHandler : IRequestHandler<DeleteRollerCommand, ErrorOr<RollerResponse>>
    {
        private readonly IRollerRepository _rollerRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMachineryRepository _machineryRepository;

        public DeleteRollerCommandHandler(IRollerRepository rollerRepository,
                                            UserManager<User> userManager,
                                            IMachineryRepository machineryRepository)
        {
            _rollerRepository = rollerRepository;
            _userManager = userManager;
            _machineryRepository = machineryRepository;
        }

        public async Task<ErrorOr<RollerResponse>> Handle(DeleteRollerCommand request, CancellationToken cancellationToken)
        {

            var user = await _userManager.GetUserAsync(request.context.User);
            var roleUser = await _userManager.GetRolesAsync(user);


            if (user.Id is null && roleUser.Contains("Worker"))
            {
                return Errors.ExcavatorBucket.UserDoesNotLogged;
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
