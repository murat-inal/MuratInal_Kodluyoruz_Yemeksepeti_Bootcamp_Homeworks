using Homework_4_Q4.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_4_Q4.Entity
{
    public class Teacher : IEntity
    {
        [Required]
        public int TeacherId { get; set; }
        [StringLength(50, ErrorMessage = "Must be between 3-50 characters", MinimumLength = 3)]
        public string TeacherName { get; set; }
        [StringLength(50, ErrorMessage = "Must be between 3-50 characters", MinimumLength = 3)]
        public string TeacherSurname { get; set; }
        [RangeAttribute(20,65)]
        public short TeacherAge { get; set; }
    }
}
