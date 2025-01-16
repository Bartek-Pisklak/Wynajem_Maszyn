using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.ExcavatorBucketAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Common.Errors;
using Microsoft.AspNetCore.Identity;

namespace WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.DeleteExcavatorBuckets
{
    public class DeleteExcavatorBucketCommandHandler :IRequestHandler<DeleteExcavatorBucketCommand, ErrorOr<ExcavatorBucketResponse>>
    {
        private readonly IExcavatorBucketRepository _excavatorBucketRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMachineryRepository _machineryRepository;

        public DeleteExcavatorBucketCommandHandler(IExcavatorBucketRepository excavatorBucketRepository,
            UserManager<User> userManager,
            IMachineryRepository machineryRepository)
        {
            _excavatorBucketRepository=excavatorBucketRepository;
            _userManager=userManager;
            _machineryRepository=machineryRepository;
        }

        public async Task<ErrorOr<ExcavatorBucketResponse>> Handle(DeleteExcavatorBucketCommand request, CancellationToken cancellationToken)
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
            await _excavatorBucketRepository.DeleteExcavatorBucket(id);


            return new ExcavatorBucketResponse("ExcavatorBucket delete");
        }
    }


}
