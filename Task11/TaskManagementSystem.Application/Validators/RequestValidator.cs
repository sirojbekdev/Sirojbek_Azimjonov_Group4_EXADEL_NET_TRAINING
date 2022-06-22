using FluentValidation;
using TaskManagementSystem.Domain.Models;

namespace TaskManagementSystem.Application.Validators
{
    public class RequestValidator : AbstractValidator<AuthenticateRequest>
    {
        public RequestValidator()
        {
            RuleFor(x=>x.Email).NotNull().EmailAddress();
            RuleFor(x => x.Password).NotNull();
        }
    }
}
