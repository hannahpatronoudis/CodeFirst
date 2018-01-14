using StudentCodeFirst.DomainClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCodeFirst.DataLayer
{
    public class StudentContext : DbContext
    {

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }

        public StudentContext() : base("EF1DB")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*
             * NIET NODIG > CONVENTIES VAN EF ZIJN VOLDOENDE
            modelBuilder.Entity<Student>().HasKey(s => s.Id);
            modelBuilder.Entity<Enrollment>().HasKey(e => e.EnrollmentId);
            modelBuilder.Entity<Course>().HasKey(c => c.CourseId);

            //Een enrollment heeft verplicht een student en een student heeft optioneel een enrollment
            modelBuilder.Entity<Enrollment>().HasRequired(e => e.Student).WithOptional(s => s.Enrollments);
            //Een enrollment heeft verplicht een course en een course heeft optioneel een enrollment
            modelBuilder.Entity<Enrollment>().HasRequired(e => e.Course).WithOptional(c => c.Enrollments);
            */ 

            base.OnModelCreating(modelBuilder);
        }

    }
}
