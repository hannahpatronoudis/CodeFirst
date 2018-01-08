using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace StudentCodeFirst.DomainClasses
{
    public class Student
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public virtual Enrollment Enrollments { get; set; }


    }
}
