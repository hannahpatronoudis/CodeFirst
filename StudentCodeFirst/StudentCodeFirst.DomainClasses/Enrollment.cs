using StudentCodeFirst.DomainClasses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCodeFirst.DomainClasses
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public GradeType Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }

    }
}
