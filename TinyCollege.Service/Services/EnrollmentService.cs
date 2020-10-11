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

        public IQueryable<Enrollment> CreateEnrollment(Enrollment enrollment)
        {
            _context.Add(enrollment);
            _context.SaveChanges();
            return _context.Enrollments.Where(x => x.EnrollmentId == _context.Enrollments.Max(x => x.EnrollmentId));
        }

        public IQueryable<Student> GetEnrollmentStudent(int enrollmentStudentId)
        {
            return _context.Students.Where(x => x.StudentId == enrollmentStudentId);
        }

        public IQueryable<Section> GetEnrollmentSection(int enrollmentSectionId)
        {
            return _context.Sections.Where(x => x.SectionId == enrollmentSectionId);
        }

        public IQueryable<Enrollment> DeleteEnrollment(Enrollment enrollment)
        {
            try
            {
                _context.Enrollments.Attach(enrollment);
                _context.Enrollments.Remove(enrollment);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // ignored
            }

            return _context.Enrollments;
        }
    }
}
