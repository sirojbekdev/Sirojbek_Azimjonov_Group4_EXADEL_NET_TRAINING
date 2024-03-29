﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Models
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
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<ClassSubject> ClassSubjects { get; set; }
    }
}
