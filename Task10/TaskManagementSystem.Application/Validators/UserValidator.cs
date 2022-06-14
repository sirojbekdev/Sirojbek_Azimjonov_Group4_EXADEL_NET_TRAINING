using FluentValidation;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.FullName).NotNull().MaximumLength(50);
            RuleFor(x => x.RoleId).NotNull();
            RuleFor(x => x.Email).NotNull().MaximumLength(100).EmailAddress();
            RuleFor(x => x.Password).NotNull().Length(7, 20);
        }
    }
}
