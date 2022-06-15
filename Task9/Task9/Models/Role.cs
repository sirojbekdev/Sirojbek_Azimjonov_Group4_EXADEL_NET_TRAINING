using FluentValidation;
using System.Text.Json.Serialization;

namespace Task9.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }

    public class RoleValidator : AbstractValidator<Role>
    {
        public RoleValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotNull().MaximumLength(50);
        }
    }
}
