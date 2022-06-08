using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Task9.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        ICollection<User> Users { get; set; }
    }

    public class RoleValidator : AbstractValidator<Role>
    {
        public RoleValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotNull().Length(1,50);
        }
    }
}
