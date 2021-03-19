using Homework_4_Q4.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_4_Q4.Entity
{
    public class Student : IEntity
    {
        [Required]
        public int StudentId { get; set; }
        [StringLength(50,ErrorMessage ="Must be between 3-50 characters",MinimumLength =3)]
        public string StudentName { get; set; }
        [StringLength(50, ErrorMessage = "Must be between 3-50 characters", MinimumLength = 3)]
        public string StudentSurname { get; set; }
        [RangeAttribute(6,15)]
        public short StudentAge { get; set; }
    }
}
