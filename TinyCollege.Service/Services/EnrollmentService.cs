using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models;

namespace TinyCollege.Service.Services
{
    public class EnrollmentService : BaseService
    {
        public EnrollmentService() : base()
        {
        }

        public IQueryable<Enrollment> GetEnrollments()
        {
            return _context.Enrollments;
        }

        public IQueryable<Student> GetEnrollmentStudent(int enrollmentStudentId)
        {
            return _context.Students.Where(x => x.StudentId == enrollmentStudentId);
        }

        public IQueryable<Section> GetEnrollmentSection(int enrollmentSectionId)
        {
            return _context.Sections.Where(x => x.SectionId == enrollmentSectionId);
        }
    }
}
