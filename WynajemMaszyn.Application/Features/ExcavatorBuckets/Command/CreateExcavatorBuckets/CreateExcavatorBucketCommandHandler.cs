using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Contracts.ExcavatorBucketAnswer;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.CreateExcavatorBuckets
{
    public class CreateExcavatorBucketCommandHandler : IRequestHandler<CreateExcavatorBucketCommand, ErrorOr<ExcavatorBucketResponse>>
    {
        private readonly IExcavatorBucketRepository _excavatorBucketRepository;
        private readonly IUserContextGetIdService _userContextGetId;


        public CreateExcavatorBucketCommandHandler(IExcavatorBucketRepository excavatorBucketRepository, IUserContextGetIdService userContextGetId)
        {
            _excavatorBucketRepository=excavatorBucketRepository;
            _userContextGetId=userContextGetId;
        }

        public async Task<ErrorOr<ExcavatorBucketResponse>> Handle(CreateExcavatorBucketCommand request, CancellationToken cancellationToken)
        {
            var userId = 1;//_userContextGetId.GetUserId;

            /*            if (userId is null)
                        {
                            return Errors.WorkTask.UserDoesNotLogged;
                        }*/

            var excavatorBucket = new ExcavatorBucket
            {
                IdUser = (int)userId,
                Name = request.Name,
                Description = request.Description
            };

            await _excavatorBucketRepository.CreateExcavatorBucket(excavatorBucket);

            return new ExcavatorBucketResponse("ExcavatorBucket added");

        }
    }

}
