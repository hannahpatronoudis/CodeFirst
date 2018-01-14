using StudentCodeFirst.DataLayer;
using StudentCodeFirst.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesModel.Repositories
{
    class StudentRepository : IDisposable
    {

        private readonly StudentContext _context;

        public StudentRepository()
        {
            _context = new StudentContext();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private static void AddStudent()
        {
            var student = new Student
            {
                Lastname = "Patronoudis",
                FirstMidName = "Hannah",
                EnrollmentDate = DateTime.Now,
                //Enrollments = new Enrollment { }
            };

            using (var context = new StudentContext())
            {
                context.Students.Add(student);
                context.SaveChanges();
            }
        }

        private static void ModifyStudent(string firstname, string newFirstname)
        {
            using (var context = new StudentContext())
            {
                var student = context.Students.FirstOrDefault(c => c.FirstMidName == firstname);

                if (student != null)
                {
                    student.FirstMidName = newFirstname;
                    context.SaveChanges();
                }
            }
        }

        private static void DeleteStudent(string lastname)
        {
            using (var context = new StudentContext())
            {
                var studentsToDelete = context.Students.Where(c => c.Lastname == lastname);

                foreach (var student in studentsToDelete)
                {
                    context.Students.Remove(student);
                }
            }
        }

        //Retrieve all students and at the same time

        private static void GetStudents()
        {
            using (var context = new StudentContext())
            {
                var allStudents = context.Students.ToList();

                foreach (var student in allStudents)
                {
                    Console.WriteLine($"{student.Lastname} - {student.FirstMidName}");
                }
            }
        }
    }
}
