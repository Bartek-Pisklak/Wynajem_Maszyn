using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.HarversterAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;
using Microsoft.AspNetCore.Identity;


namespace WynajemMaszyn.Application.Features.Harvesters.Command.DeleteHarvesters
{
    public class DeleteHarvesterCommandHandler : IRequestHandler<DeleteHarvesterCommand, ErrorOr<HarvesterResponse>>
    {
        private readonly IHarvesterRepository _harvesterRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMachineryRepository _machineryRepository;

        public DeleteHarvesterCommandHandler(IHarvesterRepository harvesterRepository,
                                            UserManager<User> userManager,
                                            IMachineryRepository machineryRepository)
        {
            _harvesterRepository = harvesterRepository;
            _userManager = userManager;
            _machineryRepository = machineryRepository;
        }

        public async Task<ErrorOr<HarvesterResponse>> Handle(DeleteHarvesterCommand request, CancellationToken cancellationToken)
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
                HarvesterId= id
            };
            await _machineryRepository.DeleteMachinery(machinery);
            await _harvesterRepository.DeleteHarvester(id);

            return new HarvesterResponse("Harvester delete");
        }
    }
}
