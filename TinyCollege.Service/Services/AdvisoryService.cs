using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Service.Services
{
    public class AdvisoryService : BaseService
    {
        public AdvisoryService() : base()
        {
        }

        public IQueryable<Advisory> GetAdvisories()
        {
            return _context.Advisories;
        }

        public IQueryable<Advisory> CreateAdvisory(Advisory advisory)
        {
            _context.Add(advisory);
            _context.SaveChanges();
            return _context.Advisories.Where(x => x.AdvisoryId == _context.Advisories.Max(x => x.AdvisoryId));
        }

        public IQueryable<Department> GetAdvisoryDepartment(int advisoryDepartmentId)
        {
            return _context.Departments.Where(x => x.DepartmentId == advisoryDepartmentId);
        }

        public IQueryable<Professor> GetAdvisoryProfessor(int advisoryProfessorId)
        {
            return _context.Professors.Where(x => x.ProfessorId == advisoryProfessorId);
        }

        public IQueryable<Student> GetAdvisoryStudent(int advisoryStudentId)
        {
            return _context.Students.Where(x => x.StudentId == advisoryStudentId);
        }
    }
}
