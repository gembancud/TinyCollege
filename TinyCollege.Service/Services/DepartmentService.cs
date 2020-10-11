using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models;

namespace TinyCollege.Service.Services
{
    public class DepartmentService : BaseService
    {
        public DepartmentService() : base()
        {
        }

        public IQueryable<Department> GetDepartments()
        {
            return _context.Departments;
        }

        public IQueryable<Department> CreateDepartment(Department department)
        {
            _context.Add(department);
            _context.SaveChanges();
            return _context.Departments.Where(x => x.DepartmentId == _context.Departments.Max(x => x.DepartmentId));
        }

        public IQueryable<School> GetDepartmentSchool(int departmentSchoolId)
        {
            return _context.Schools.Where(x => x.SchoolId == departmentSchoolId);
        }

        public IQueryable<Tenure> GetDepartmentTenures(int departmentId)
        {
            return _context.Tenures.Where(x => x.DepartmentId == departmentId);
        }

        public IQueryable<Professorship> GetDepartmentProfessorships(int departmentId)
        {
            return _context.Professorships.Where(x => x.DepartmentId == departmentId);
        }

        public IQueryable<Course> GetDepartmentCourses(int departmentId)
        {
            return _context.Courses.Where(x => x.DepartmentId == departmentId);
        }

        public IQueryable<Student> GetDepartmentStudents(int departmentId)
        {
            return _context.Students.Where(x => x.DepartmentId == departmentId);
        }

        public IQueryable<Advisory> GetDepartmentAdvisoriess(int departmentId)
        {
            return _context.Advisories.Where(x => x.DepartmentId == departmentId);
        }

        public IQueryable<Department> DeleteDepartment(Department department)
        {
            try
            {
                _context.Departments.Attach(department);
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // ignored
            }

            return _context.Departments;
        }
    }
}
