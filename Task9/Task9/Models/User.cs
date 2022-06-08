using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Task9.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Task> Creators { get; set; }
        public ICollection<Task> Performers { get; set; }
    }

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.FullName).NotNull().Length(1,50);
            RuleFor(x => x.RoleId).NotNull();
            RuleFor(x => x.Email).NotNull().EmailAddress().Length(1,100);
            RuleFor(x => x.Password).NotNull().Length(7, 20);
        }
    }
}
