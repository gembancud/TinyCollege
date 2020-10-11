using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models;

namespace TinyCollege.Service.Services
{
    public class CourseService : BaseService
    {
        public CourseService() : base()
        {
        }

        public IQueryable<Course> GetCourses()
        {
            return _context.Courses;
        }

        public IQueryable<Course> CreateCourse(Course course)
        {
            _context.Add(course);
            _context.SaveChanges();
            return _context.Courses.Where(x => x.CourseId == _context.Courses.Max(x => x.CourseId));
        }

        public IQueryable<Section> GetCourseSections(int courseId)
        {
            return _context.Sections.Where(x => x.CourseId == courseId);
        }

        public IQueryable<Department> GetCourseDepartment(int courseDepartmentId)
        {
            return _context.Departments.Where(x => x.DepartmentId == courseDepartmentId);
        }

        public IQueryable<Course> DeleteCourse(Course course)
        {
            try
            {
                _context.Courses.Attach(course);
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // ignored
            }

            return _context.Courses;
        }
    }
}
