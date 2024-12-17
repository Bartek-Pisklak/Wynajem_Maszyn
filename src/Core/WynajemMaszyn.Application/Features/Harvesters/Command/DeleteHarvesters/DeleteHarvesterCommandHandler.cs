﻿using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.HarversterAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;


namespace WynajemMaszyn.Application.Features.Harvesters.Command.DeleteHarvesters
{
    public class DeleteHarvesterCommandHandler : IRequestHandler<DeleteHarvesterCommand, ErrorOr<HarvesterResponse>>
    {
        private readonly IHarvesterRepository _harvesterRepository;
        private readonly IUserContextGetIdService _userContextGetId;
        private readonly IMachineryRepository _machineryRepository;

        public DeleteHarvesterCommandHandler(IHarvesterRepository harvesterRepository,
                                            IUserContextGetIdService userContextGetId,
                                            IMachineryRepository machineryRepository)
        {
            _harvesterRepository = harvesterRepository;
            _userContextGetId = userContextGetId;
            _machineryRepository = machineryRepository;
        }

        public async Task<ErrorOr<HarvesterResponse>> Handle(DeleteHarvesterCommand request, CancellationToken cancellationToken)
        {
            var userId = _userContextGetId.GetUserId;

            if (userId is null)
            {
                return Errors.Harvester.UserDoesNotLogged;
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
