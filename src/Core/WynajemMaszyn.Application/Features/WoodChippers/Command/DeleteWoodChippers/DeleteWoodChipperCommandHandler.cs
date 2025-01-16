using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.WoodChipperAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;
using Microsoft.AspNetCore.Identity;

namespace WynajemMaszyn.Application.Features.WoodChippers.Command.DeleteWoodChippers
{
    public class DeleteWoodChipperCommandHandler : IRequestHandler<DeleteWoodChipperCommand, ErrorOr<WoodChipperResponse>>
    {
        private readonly IWoodChipperRepository _woodChipperRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMachineryRepository _machineryRepository;

        public DeleteWoodChipperCommandHandler(IWoodChipperRepository woodChipperRepository,
                                                UserManager<User> userManager,
                                                IMachineryRepository machineryRepository)
        {
            _woodChipperRepository= woodChipperRepository;
            _userManager= userManager;
            _machineryRepository= machineryRepository;
        }

        public async Task<ErrorOr<WoodChipperResponse>> Handle(DeleteWoodChipperCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(request.context.User);
            var roleUser = await _userManager.GetRolesAsync(user);


            if (user.Id is null && roleUser.Contains("Worker"))
            {
                return Errors.ExcavatorBucket.UserDoesNotLogged;
            }

            var id = request.Id;
            var machinery = new Machinery
            {
                WoodChipperId=id
            };
            await _machineryRepository.DeleteMachinery(machinery);
            await _woodChipperRepository.DeleteWoodChipper(id);

            return new WoodChipperResponse("WoodChipper delete");
        }
    }
}
