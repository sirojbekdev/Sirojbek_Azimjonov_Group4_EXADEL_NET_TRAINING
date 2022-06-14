using FluentValidation;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Validators
{
    public class TaskValidator : AbstractValidator<TaskItem>
    {
        public TaskValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotNull().MaximumLength(50);
            RuleFor(x => x.Description).MaximumLength(2000);
            RuleFor(x => x.Status).NotNull();
            RuleFor(x => x.CreatorId).NotNull();
        }
    }
}
