using FluentValidation;
using System.Text.Json.Serialization;

namespace Task9.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int RoleId { get; set; }
        public virtual Role? Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public virtual ICollection<Task> Creators { get; set; }
        [JsonIgnore]
        public virtual ICollection<Task> Performers { get; set; }
    }

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
