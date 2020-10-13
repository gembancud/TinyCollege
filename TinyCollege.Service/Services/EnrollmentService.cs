using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
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

        public List<Enrollment> GetEnrollments(string query)
        {
            var stringProperties = typeof(Enrollment).GetProperties().Where(prop =>
                prop.PropertyType == typeof(string) ||
                prop.PropertyType == typeof(int) ||
                prop.PropertyType == typeof(int?)
            );

            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Enrollments.Where(
                delegate (Enrollment x)
                {
                    return stringProperties.Any(prop => (prop.PropertyType == typeof(int) && prop.GetValue(x)?.ToString() == query) ||
                                                        (prop.PropertyType == typeof(int?) && prop.GetValue(x)?.ToString() == query) ||
                                                        (prop.PropertyType == typeof(string) && EF.Functions.Like(prop.GetValue(x)?.ToString(), $"%{query}%")));
                }
            ).ToList();
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
