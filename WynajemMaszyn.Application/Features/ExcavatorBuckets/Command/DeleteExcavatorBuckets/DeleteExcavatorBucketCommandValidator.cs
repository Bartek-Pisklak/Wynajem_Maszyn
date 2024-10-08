using FluentValidation;


namespace WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.DeleteExcavatorBuckets
{
    public class DeleteExcavatorBucketCommandValidator : AbstractValidator<DeleteExcavatorBucketCommand>
    {

        public DeleteExcavatorBucketCommandValidator() 
        {
            RuleFor(x => x.Id)
    .NotEmpty().WithMessage("Id is required");
        }
    }
}
