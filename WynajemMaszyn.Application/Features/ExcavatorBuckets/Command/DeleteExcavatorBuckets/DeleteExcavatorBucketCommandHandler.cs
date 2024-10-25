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
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.DeleteExcavatorBuckets
{
    public class DeleteExcavatorBucketCommandHandler :IRequestHandler<DeleteExcavatorBucketCommand, ErrorOr<ExcavatorBucketResponse>>
    {
        private readonly IExcavatorBucketRepository _excavatorBucketRepository;
        private readonly IUserContextGetIdService _userContextGetId;
        private readonly IMachineryRepository _machineryRepository;

        public DeleteExcavatorBucketCommandHandler(IExcavatorBucketRepository excavatorBucketRepository,
            IUserContextGetIdService userContextGetId,
            IMachineryRepository machineryRepository)
        {
            _excavatorBucketRepository=excavatorBucketRepository;
            _userContextGetId=userContextGetId;
            _machineryRepository=machineryRepository;
        }

        public async Task<ErrorOr<ExcavatorBucketResponse>> Handle(DeleteExcavatorBucketCommand request, CancellationToken cancellationToken)
        {
            var userId = 1;//_userContextGetId.GetUserId;

            /*            if (userId is null)
                        {
                            return Errors.WorkTask.UserDoesNotLogged;
                        }*/
            int id = request.Id;
            var machinery = new Machinery
            {
                ExcavatorId= id
            };
            await _excavatorBucketRepository.DeleteExcavatorBucket(id);
            await _machineryRepository.DeleteMachinery(machinery);

            return new ExcavatorBucketResponse("ExcavatorBucket delete");
        }
    }


}
