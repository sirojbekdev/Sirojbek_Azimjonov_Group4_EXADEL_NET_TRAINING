using FluentValidation;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(2000)]
        public string Description { get; set; }
        [Required]
        public Statuses Status { get; set; }
        [Required]
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        public int PerformerId { get; set; }
        public User Performer { get; set; }
    }
    public class TaskValidator : AbstractValidator<Models.Task>
    {
        public TaskValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotNull().Length(1,50);
            RuleFor(x => x.Description).Length(0,2000);
            RuleFor(x => x.Status).NotNull();
            RuleFor(x=> x.CreatorId).NotNull();
        }
    }
}
