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

        public List<Department> GetDepartments()
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Departments.ToList();
        }

        public List<Department> CreateDepartment(Department department)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            _context.Add(department);
            _context.SaveChanges();
            return _context.Departments.Where(x => x.DepartmentId == _context.Departments.Max(x => x.DepartmentId)).ToList();
        }

        public List<School> GetDepartmentSchool(int departmentSchoolId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Schools.Where(x => x.SchoolId == departmentSchoolId).ToList();
        }

        public List<Tenure> GetDepartmentTenures(int departmentId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Tenures.Where(x => x.DepartmentId == departmentId).ToList();
        }

        public List<Professorship> GetDepartmentProfessorships(int departmentId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Professorships.Where(x => x.DepartmentId == departmentId).ToList();
        }

        public List<Course> GetDepartmentCourses(int departmentId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Courses.Where(x => x.DepartmentId == departmentId).ToList();
        }

        public List<Student> GetDepartmentStudents(int departmentId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Students.Where(x => x.DepartmentId == departmentId).ToList();
        }

        public List<Advisory> GetDepartmentAdvisoriess(int departmentId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Advisories.Where(x => x.DepartmentId == departmentId).ToList();
        }

        public List<Department> DeleteDepartment(Department department)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

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

            return _context.Departments.ToList();
        }

        public List<Department> EditDepartment(Department department)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            var tmpDepartment = _context.Departments.First(x => x.DepartmentId == department.DepartmentId);
            _context.Entry(tmpDepartment).CurrentValues.SetValues(department);
            _context.SaveChanges();
            return _context.Departments.Where(x => x.DepartmentId == department.DepartmentId).ToList();
        }
    }
}
