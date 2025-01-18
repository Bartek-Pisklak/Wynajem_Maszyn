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
        private readonly IMachineryRepository _machineryRepository;
        private readonly ICurrentUserService _currentUserService;

        public DeleteExcavatorBucketCommandHandler(IExcavatorBucketRepository excavatorBucketRepository,
            IMachineryRepository machineryRepository,
            ICurrentUserService currentUserService)
        {
            _excavatorBucketRepository=excavatorBucketRepository;
            _machineryRepository=machineryRepository;
            _currentUserService=currentUserService;
        }

        public async Task<ErrorOr<ExcavatorBucketResponse>> Handle(DeleteExcavatorBucketCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var roles = _currentUserService.Roles;

            if (string.IsNullOrEmpty(userId) || !roles.Contains("Worker"))
            {
                return Errors.ExcavatorBucket.UserDoesNotLogged;
            }

            var machinery = new Machinery
            {
                ExcavatorId= request.Id
            };
            await _machineryRepository.DeleteMachinery(machinery);
            await _excavatorBucketRepository.DeleteExcavatorBucket(request.Id);


            return new ExcavatorBucketResponse("ExcavatorBucket delete");
        }
    }


}
