using FluentValidation;
using System.Text;
using static Task9.Models.Task;

namespace Task9.Models
{
    public class TaskViewModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public Statuses Status { get; set; }
        public int CreatorId { get; set; }
        public int? PerformerId { get; set; }
    }

    public class TaskVMValidator : AbstractValidator<TaskViewModel>
    {

        public TaskVMValidator()
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
