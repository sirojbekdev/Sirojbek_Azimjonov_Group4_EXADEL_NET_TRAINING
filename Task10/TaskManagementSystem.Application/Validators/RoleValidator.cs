using FluentValidation;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Validators
{
    public class RoleValidator : AbstractValidator<Role>
    {
        public RoleValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotNull().MaximumLength(50);
        }
    }
}
