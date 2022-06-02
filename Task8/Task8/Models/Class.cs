using System.ComponentModel.DataAnnotations;

namespace Task7.Models
{
    public class Class
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        [StringLength(50)]
        public string Letter { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<ClassSubject> ClassSubjects { get; set; }
    }
}
