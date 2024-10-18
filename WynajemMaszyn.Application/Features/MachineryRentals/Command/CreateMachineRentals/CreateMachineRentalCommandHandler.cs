using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Application.Contracts.MachineryRentalAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Features.MachineryRentals.Command.CreateMachineRentals
{
    public class CreateMachineRentalCommandHandler : IRequestHandler<CreateMachineRentalCommand, ErrorOr<MachineryRentalResponse>
    {
        private readonly IMachineryRentalRepository _machineryRentalRepository;
        private readonly IUserContextGetIdService _userContextGetId;


        public CreateMachineRentalCommandHandler(
            IMachineryRentalRepository machineryRentalRepository,
            IUserContextGetIdService userContextGetIdService
            )
        {
            _machineryRentalRepository = machineryRentalRepository;
            _userContextGetId = userContextGetIdService;
        }

        public async Task<ErrorOr<MachineryRentalResponse>> Handle(CreateMachineRentalCommand request, CancellationToken cancellationToken)
        {
            var userId = 1;//_userContextGetId.GetUserId;

            /*            if (userId is null)
                        {
                            return Errors.WorkTask.UserDoesNotLogged;
                        }*/
            var machineryRent = new MachineryRental
            {

            };



            await _machineryRentalRepository.CreateMachineryRental(machineryRent);

            return new MachineryRentalResponse("Order created");
        }
    }
}
