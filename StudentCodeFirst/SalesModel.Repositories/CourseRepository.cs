using StudentCodeFirst.DataLayer;
using StudentCodeFirst.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesModel.Repositories
{
    class CourseRepository : IDisposable
    {
        private readonly StudentContext _context;

        public CourseRepository()
        {
            _context = new StudentContext();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
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
    }
}
