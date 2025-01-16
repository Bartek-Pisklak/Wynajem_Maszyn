using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.MachineryRentalAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;
using Microsoft.AspNetCore.Identity;


namespace WynajemMaszyn.Application.Features.MachineryRentals.Command.CreateMachineRentals
{
    public class CreateMachineRentalCommandHandler : IRequestHandler<CreateMachineRentalCommand, ErrorOr<MachineryRentalResponse>>
    {
        private readonly IMachineryRentalRepository _machineryRentalRepository;
        private readonly UserManager<User> _userManager;


        public CreateMachineRentalCommandHandler(
            IMachineryRentalRepository machineryRentalRepository,
            UserManager<User> userManager
            )
        {
            _machineryRentalRepository = machineryRentalRepository;
            _userManager = userManager;
        }

        public async Task<ErrorOr<MachineryRentalResponse>> Handle(CreateMachineRentalCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(request.context.User);
            var roleUser = await _userManager.GetRolesAsync(user);


            if (user.Id is null && roleUser.Contains("Worker"))
            {
                return Errors.ExcavatorBucket.UserDoesNotLogged;
            }



            var machineryRent = new MachineryRental
            {

            };



            await _machineryRentalRepository.CreateMachineryRental(machineryRent);

            return new MachineryRentalResponse("Order created");
        }
    }
}
