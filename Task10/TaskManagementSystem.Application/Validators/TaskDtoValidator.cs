using FluentValidation;
using System.Text;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Validators
{
    public class TaskDtoValidator : AbstractValidator<TaskDto>
    {
        public TaskDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(50);
            RuleFor(x => x.Description).MaximumLength(2000);
            RuleFor(x => x.Status).NotNull();
            RuleFor(x => x.CreatorId).NotNull();
        }

        public string GetErrorMessage(FluentValidation.Results.ValidationResult result)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var failure in result.Errors)
            {
                stringBuilder.AppendLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
            }
            return stringBuilder.ToString();
        }
    }
}
