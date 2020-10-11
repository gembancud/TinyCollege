using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models;

namespace TinyCollege.Service.Services
{
    public class StudentService : BaseService
    {
        public StudentService() : base()
        {
        }

        public IQueryable<Student> GetStudents()
        {
            return _context.Students;
        }

        public IQueryable<Student> CreateStudent(Student student)
        {
            _context.Add(student);
            _context.SaveChanges();
            return _context.Students.Where(x => x.StudentId == _context.Students.Max(x => x.StudentId));
        }

        public IQueryable<Department> GetStudentDepartment(int studentDepartmentId)
        {
            return _context.Departments.Where(x => x.DepartmentId == studentDepartmentId);
        }

        public IQueryable<Advisory> GetStudentAdvisory(int studentAdvisoryId)
        {
            return _context.Advisories.Where(x => x.AdvisoryId == studentAdvisoryId);
        }

        public IQueryable<Enrollment> GetStudentEnrollments(int studentId)
        {
            return _context.Enrollments.Where(x => x.StudentId == studentId);
        }

        public IQueryable<Student> DeleteStudent(Student student)
        {
            try
            {
                _context.Students.Attach(student);
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // ignored
            }

            return _context.Students;
        }
    }
}