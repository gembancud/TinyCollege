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

        public List<Course> GetCourses()
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Courses.ToList();
        }

        public List<Course> CreateCourse(Course course)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            _context.Add(course);
            _context.SaveChanges();
            return _context.Courses.Where(x => x.CourseId == _context.Courses.Max(x => x.CourseId)).ToList();
        }

        public List<Section> GetCourseSections(int courseId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Sections.Where(x => x.CourseId == courseId).ToList();
        }

        public List<Department> GetCourseDepartment(int courseDepartmentId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Departments.Where(x => x.DepartmentId == courseDepartmentId).ToList();
        }

        public List<Course> DeleteCourse(Course course)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

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

            return _context.Courses.ToList();
        }

        public List<Course> EditCourse(Course course)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            var tmpCourse = _context.Courses.First(x => x.CourseId == course.CourseId);
            _context.Entry(tmpCourse).CurrentValues.SetValues(course);
            _context.SaveChanges();
            return _context.Courses.Where(x => x.CourseId == course.CourseId).ToList();
        }
    }
}
