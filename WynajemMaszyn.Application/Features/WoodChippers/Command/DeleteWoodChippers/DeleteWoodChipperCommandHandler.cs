using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Application.Contracts.WoodChipperAnswer;
using WynajemMaszyn.Application.Features.WoodChippers.Command.CreateWoodChippers;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Features.WoodChippers.Command.DeleteWoodChippers
{
    public class DeleteWoodChipperCommandHandler : IRequestHandler<DeleteWoodChipperCommand, ErrorOr<WoodChipperResponse>>
    {
        private readonly IWoodChipperRepository _woodChipperRepository;
        private readonly IUserContextGetIdService _userContextGetId;
        private readonly IMachineryRepository _machineryRepository;

        public DeleteWoodChipperCommandHandler(IWoodChipperRepository woodChipperRepository,
                                                IUserContextGetIdService userContextGetIdService,
                                                IMachineryRepository machineryRepository)
        {
            _woodChipperRepository= woodChipperRepository;
            _userContextGetId= userContextGetIdService;
            _machineryRepository= machineryRepository;
        }

        public async Task<ErrorOr<WoodChipperResponse>> Handle(DeleteWoodChipperCommand request, CancellationToken cancellationToken)
        {
            var userId = 1;//_userContextGetId.GetUserId;

            /*            if (userId is null)
                        {
                            return Errors.WorkTask.UserDoesNotLogged;
                        }*/

            var id = request.Id;
            var machinery = new Machinery
            {
                WoodChipperId=id
            };

            await _woodChipperRepository.DeleteWoodChipper(id);
            await _machineryRepository.DeleteMachinery(machinery);

            return new WoodChipperResponse("WoodChipper delete");
        }
    }
}
