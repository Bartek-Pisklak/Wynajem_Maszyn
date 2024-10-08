using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Application.Contracts.ExcavatorAnswer;
using WynajemMaszyn.Application.Contracts.ExcavatorBucketAnswer;
using WynajemMaszyn.Application.Persistance;

namespace WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.DeleteExcavatorBuckets
{
    public class DeleteExcavatorBucketCommandHandler :IRequestHandler<DeleteExcavatorBucketCommand, ErrorOr<ExcavatorBucketResponse>>
    {
        private readonly IExcavatorBucketRepository _excavatorBucketRepository;
        private readonly IUserContextGetIdService _userContextGetId;

        public DeleteExcavatorBucketCommandHandler(IExcavatorBucketRepository excavatorBucketRepository, IUserContextGetIdService userContextGetId)
        {
            _excavatorBucketRepository = excavatorBucketRepository;
            _userContextGetId = userContextGetId;
        }

        public async Task<ErrorOr<ExcavatorBucketResponse>> Handle(DeleteExcavatorBucketCommand request, CancellationToken cancellationToken)
        {
            var userId = 1;//_userContextGetId.GetUserId;

            /*            if (userId is null)
                        {
                            return Errors.WorkTask.UserDoesNotLogged;
                        }*/
            int id = request.Id;
            await _excavatorBucketRepository.DeleteExcavatorBucket(id);

            return new ExcavatorBucketResponse("ExcavatorBucket delete");
        }
    }


}
