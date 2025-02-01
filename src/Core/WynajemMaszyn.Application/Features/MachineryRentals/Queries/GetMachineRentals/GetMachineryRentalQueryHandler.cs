using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Features.MachineryRentals.Queries.DTOs;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.Common.Errors;


namespace WynajemMaszyn.Application.Features.MachineryRentals.Queries.GetMachineRentals
{
    public class GetMachineryRentalQueryHandler : IRequestHandler<GetMachineryRentalQuery, ErrorOr<GetMachineryRentalDto>>
    {
        private readonly IMachineryRentalRepository _machineryRentalRepository;
        private readonly ICurrentUserService _currentUserService;

        public GetMachineryRentalQueryHandler(
            IMachineryRentalRepository machineryRentalRepository,
            ICurrentUserService currentUserService)
        {
            _machineryRentalRepository = machineryRentalRepository;
            _currentUserService = currentUserService;
        }

        public async Task<ErrorOr<GetMachineryRentalDto>> Handle(GetMachineryRentalQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var roles = _currentUserService.Roles;

            if (string.IsNullOrEmpty(userId))
            {
                return Errors.MachineRental.UserDoesNotLogged;
            }

            int IdCard;
            if(request.IdCard is null)
            {
                IdCard = await _machineryRentalRepository.GetIdCardUser(userId);
            }
            else
            {
                IdCard =(int)request.IdCard;
            }

            if (roles.Contains("Client"))
            {
                var haveIdConfirmed = await _machineryRentalRepository.ConfirmIdCardUser(IdCard, userId);

                if (!haveIdConfirmed)
                {
                    return Errors.MachineRental.UserDoesNotLogged;
                }
            }

            var machine = await _machineryRentalRepository.GetMachinerySmallDetails(IdCard);

            var machineryRentalDetails = await _machineryRentalRepository.GetMachineryRental(IdCard);

            if (string.IsNullOrEmpty(userId))
            {
                return Errors.MachineRental.NotDataToDisplay;
            }

            var machineryRentalOne = new GetMachineryRentalDto
            {
                Cost = machineryRentalDetails.Cost,
                BeginRent = machineryRentalDetails.BeginRent,
                EndRent = machineryRentalDetails.EndRent,
                RentalStatus = machineryRentalDetails.RentalStatus,
                Deposit = machineryRentalDetails.Deposit,
                LateFee = machineryRentalDetails.LateFee,
                PaymentStatus = machineryRentalDetails.PaymentStatus,
                Facture = machineryRentalDetails.Facture,
                Contract = machineryRentalDetails.Contract,
                PaymentMethod = machineryRentalDetails.PaymentMethod,
                AdditionalNotes = machineryRentalDetails.AdditionalNotes,
                IsReturned = machineryRentalDetails.IsReturned,
                MachineryInCard = machine.ToList()
            };

            return machineryRentalOne;
        }
    }
}
