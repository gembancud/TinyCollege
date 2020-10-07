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
    }
}
