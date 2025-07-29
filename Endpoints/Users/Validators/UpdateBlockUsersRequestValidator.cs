using FluentValidation;
using itransition_task4_server.Endpoints.Users.DTOs;

namespace itransition_task4_server.Endpoints.Users.Validators
{
    public sealed class UpdateBlockUsersRequestValidator : AbstractValidator<UpdateBlockUsersRequest>
    {
        public UpdateBlockUsersRequestValidator()
        {
            RuleFor(x => x.Ids)
                .NotNull().WithMessage("Ids must be provided.")
                .Must(ids => ids.Any())
                .WithMessage("At least one user ID must be provided.");
            RuleFor(x => x.Block)
                .NotNull().WithMessage("Block status must be provided.")
                .Must(block => block == true || block == false)
                .WithMessage("Block status must be a boolean value (true or false).");
        }
    }
}
