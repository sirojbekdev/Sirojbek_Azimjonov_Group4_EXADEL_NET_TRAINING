using System.ComponentModel.DataAnnotations;

namespace Task7.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public ICollection<ClassSubject> ClassSubjects { get; set; }
    }
}
