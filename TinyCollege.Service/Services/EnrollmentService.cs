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

        public List<Enrollment> GetEnrollments()
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Enrollments.ToList();
        }

        public List<Enrollment> CreateEnrollment(Enrollment enrollment)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            _context.Add(enrollment);
            _context.SaveChanges();
            return _context.Enrollments.Where(x => x.EnrollmentId == _context.Enrollments.Max(x => x.EnrollmentId)).ToList();
        }

        public List<Student> GetEnrollmentStudent(int enrollmentStudentId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Students.Where(x => x.StudentId == enrollmentStudentId).ToList();
        }

        public List<Section> GetEnrollmentSection(int enrollmentSectionId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Sections.Where(x => x.SectionId == enrollmentSectionId).ToList();
        }

        public List<Enrollment> DeleteEnrollment(Enrollment enrollment)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

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

            return _context.Enrollments.ToList();
        }

        public List<Enrollment> EditEnrollment(Enrollment enrollment)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            var tmpEnrollment = _context.Enrollments.First(x => x.EnrollmentId == enrollment.EnrollmentId);
            _context.Entry(tmpEnrollment).CurrentValues.SetValues(enrollment);
            _context.SaveChanges();
            return _context.Enrollments.Where(x => x.EnrollmentId == enrollment.EnrollmentId).ToList();
        }
    }
}
