using FluentValidation;
using System.Text.Json.Serialization;

namespace Task9.Models
{
    public class Task
    {
        public enum Statuses
        {
            NotStarted,
            Completed
        }
        public int Id { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }

        public Statuses Status { get; set; }

        public int CreatorId { get; set; }
        [JsonIgnore]
        public virtual User? Creator { get; set; }
        public int? PerformerId { get; set; } 
        [JsonIgnore]
        public virtual User? Performer { get; set; }
    }
    public class TaskValidator : AbstractValidator<Models.Task>
    {
        public TaskValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotNull().MaximumLength(50);
            RuleFor(x => x.Description).MaximumLength(2000);
            RuleFor(x => x.Status).NotNull();
            RuleFor(x=> x.CreatorId).NotNull();
        }
    }
}
