using System.ComponentModel.DataAnnotations;

namespace Task7.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
