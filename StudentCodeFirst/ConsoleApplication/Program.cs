using StudentCodeFirst.DataLayer;
using StudentCodeFirst.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {

        }

        //Add a student/course/enrollment
        private static void AddStudent()
        {
            var student = new Student
            {
                Lastname = "Patronoudis",
                FirstMidName = "Hannah",
                EnrollmentDate = DateTime.Now,
                Enrollments = new Enrollment { }
            };

            using (var context = new StudentContext())
            {
                context.Students.Add(student);
                context.SaveChanges();
            }
        }

        private static void AddCourse()
        {
            var course = new Course
            {
                Title = ".Net Adv.",
                Credits = 3
            };

            using (var context = new StudentContext())
            {
                context.Courses.Add(course);
                context.SaveChanges();
            }
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

        //Modify a student/course/enrollment
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

        private static void ModifyCourse(string title, string newTitle)
        {
            using (var context = new StudentContext())
            {
                var course = context.Courses.FirstOrDefault(c => c.Title == title);

                if (course != null)
                {
                    course.Title = newTitle;
                    context.SaveChanges();
                }
            }
        }

        /*
        private static void ModifyEnrollment()
        {
            using (var context = new StudentContext())
            {
                var enrollment = context.Enrollments.FirstOrDefault(c => c.);

                if (enrollment != null)
                {
                    enrollment. = newEnrollment;
                    context.SaveChanges();
                }
            }
        }
        */

        //Remove a student/course/enrollment
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

        private static void DeleteCourse(string title)
        {
            using (var context = new StudentContext())
            {
                var coursesToDelete = context.Courses.Where(c => c.Title == title);

                foreach (var course in coursesToDelete)
                {
                    context.Courses.Remove(course);
                }
            }
        }

        /*
        private static void DeleteEnrollment()
        {
            using (var context = new StudentContext())
            {
                var enrollmentsToDelete = context.Enrollments.Where(c => c. == );

                foreach (var enrollment in enrollmentsToDelete)
                {
                    context.Enrollments.Remove(enrollment);
                }
            }
        }*/

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
