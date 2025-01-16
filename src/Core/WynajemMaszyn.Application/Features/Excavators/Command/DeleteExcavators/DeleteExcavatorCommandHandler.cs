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
        private readonly UserManager<User> _userManager;
        private readonly IMachineryRepository _machineryRepository;

        public DeleteExcavatorCommandHandler(IExcavatorRepository excavatorRepository, 
            UserManager<User> userManager,
            IMachineryRepository machineryRepository)
        {
            _excavatorRepository = excavatorRepository;
            _userManager = userManager;
            _machineryRepository=machineryRepository;   
        }

        public async Task<ErrorOr<ExcavatorResponse>> Handle(DeleteExcavatorCommand request, CancellationToken cancellationToken)
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
                ExcavatorId= id
            };
            await _machineryRepository.DeleteMachinery(machinery);
            await _excavatorRepository.DeleteExcavator(id);
            return new ExcavatorResponse("Task delete");
        }
    }
}
