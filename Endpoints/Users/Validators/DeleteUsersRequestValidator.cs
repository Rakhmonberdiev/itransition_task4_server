using FluentValidation;
using itransition_task4_server.Endpoints.Users.DTOs;

namespace itransition_task4_server.Endpoints.Users.Validators
{
    public sealed class DeleteUsersRequestValidator : AbstractValidator<DeleteUsersRequest>
    {
        public DeleteUsersRequestValidator()
        {
            RuleFor(x => x.Ids)
                .NotNull().WithMessage("Ids must be provided.")
                .Must(ids => ids.Any()).WithMessage("At least one user ID must be provided.");
        }
    }
}
