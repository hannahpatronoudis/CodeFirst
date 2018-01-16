using StudentCodeFirst.DataLayer;
using StudentCodeFirst.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesModel.Repositories
{
    class EnrollmentRepository : IDisposable
    {
        private readonly StudentContext _context;

        public EnrollmentRepository()
        {
            _context = new StudentContext();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        private static void AddEnrollment()
        {
            var enrollment = new Enrollment
            {

            };

            using (var context = new StudentContext())
            {
                context.Enrollments.Add(enrollment);
                context.SaveChanges();
            }
        }

        
        private static void ModifyEnrollment(int enrollmentId, int newEnrollmentId)
        {
            using (var context = new StudentContext())
            {
                var enrollment = context.Enrollments.FirstOrDefault(c => c.EnrollmentId == enrollmentId);

                if (enrollment != null)
                {
                    enrollment.EnrollmentId = newEnrollmentId;
                    context.SaveChanges();
                }
            }
        }

        
        private static void DeleteEnrollment(int enrollmentId)
        {
            using (var context = new StudentContext())
            {
                var enrollmentsToDelete = context.Enrollments.Where(c => c.EnrollmentId == enrollmentId);

                foreach (var enrollment in enrollmentsToDelete)
                {
                    context.Enrollments.Remove(enrollment);
                }
            }
        }

        //retrieve the courses for which the students are enrolled

        private static void GetEnrolledCoursesPerStudent(int id)
        {
            using (var context = new StudentContext())
            {
                var student = context.Students.Find(id);
                var enrollment = context.Enrollments.Where(c => c.StudentId == student.Id);

                Console.WriteLine($"{student.FirstMidName} - {enrollment}");
            }
            Console.ReadKey();
        }

    }
}
