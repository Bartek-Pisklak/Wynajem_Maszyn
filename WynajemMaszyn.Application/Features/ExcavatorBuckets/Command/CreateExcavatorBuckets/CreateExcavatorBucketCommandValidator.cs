using FluentValidation;


namespace WynajemMaszyn.Application.Features.ExcavatorBuckets.Command.CreateExcavatorBuckets
{
    public class CreateExcavatorBucketCommandValidator : AbstractValidator<CreateExcavatorBucketCommand>
    {
        public CreateExcavatorBucketCommandValidator() 
        {
            RuleFor(x => x.Name)
                       .NotEmpty().WithMessage("Name is required");
        }

        // co musi miec by dodac inaczej blad
    }

}
