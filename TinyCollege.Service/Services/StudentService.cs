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

        public List<Student> GetStudents()
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            return _context.Students.ToList();
        }

        public List<Student> CreateStudent(Student student)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            _context.Add(student);
            _context.SaveChanges();
            return _context.Students.Where(x => x.StudentId == _context.Students.Max(x => x.StudentId)).ToList();
        }

        public List<Department> GetStudentDepartment(int studentDepartmentId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            return _context.Departments.Where(x => x.DepartmentId == studentDepartmentId).ToList();
        }

        public List<Advisory> GetStudentAdvisory(int studentAdvisoryId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            return _context.Advisories.Where(x => x.AdvisoryId == studentAdvisoryId).ToList();
        }

        public List<Enrollment> GetStudentEnrollments(int studentId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            return _context.Enrollments.Where(x => x.StudentId == studentId).ToList();
        }

        public List<Student> DeleteStudent(Student student)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
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

            return _context.Students.ToList();
        }

        public List<Student> EditStudent(Student student)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            var tmpStudent = _context.Students.First(x => x.StudentId == student.StudentId);
            _context.Entry(tmpStudent).CurrentValues.SetValues(student);
            _context.SaveChanges();
            return _context.Students.Where(x => x.StudentId == student.StudentId).ToList();
        }
    }
}