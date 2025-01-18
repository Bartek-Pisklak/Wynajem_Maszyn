using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.WoodChipperAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;

namespace WynajemMaszyn.Application.Features.WoodChippers.Command.DeleteWoodChippers
{
    public class DeleteWoodChipperCommandHandler : IRequestHandler<DeleteWoodChipperCommand, ErrorOr<WoodChipperResponse>>
    {
        private readonly IWoodChipperRepository _woodChipperRepository;
        private readonly IMachineryRepository _machineryRepository;
        private readonly ICurrentUserService _currentUserService;

        public DeleteWoodChipperCommandHandler(IWoodChipperRepository woodChipperRepository,
                                                IMachineryRepository machineryRepository,
                                                ICurrentUserService currentUserService)
        {
            _woodChipperRepository = woodChipperRepository;
            _machineryRepository = machineryRepository;
            _currentUserService = currentUserService;
        }

        public async Task<ErrorOr<WoodChipperResponse>> Handle(DeleteWoodChipperCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var roles = _currentUserService.Roles;

            if (string.IsNullOrEmpty(userId) || !roles.Contains("Worker"))
            {
                return Errors.ExcavatorBucket.UserDoesNotLogged;
            }

            var machinery = new Machinery
            {
                WoodChipperId=request.Id
            };
            await _machineryRepository.DeleteMachinery(machinery);
            await _woodChipperRepository.DeleteWoodChipper(request.Id);

            return new WoodChipperResponse("WoodChipper delete");
        }
    }
}
