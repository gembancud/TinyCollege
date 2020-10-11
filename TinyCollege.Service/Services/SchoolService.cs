using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models;

namespace TinyCollege.Service.Services
{
    public class SchoolService : BaseService
    {
        public SchoolService() : base()
        {
        }

        public IQueryable<School> GetSchools()
        {
            return _context.Schools;
        }

        public IQueryable<Professor> GetSchoolDean(int schoolProfessorId)
        {
            return _context.Professors.Where(x => x.ProfessorId == schoolProfessorId);
        }

        public IQueryable<Department> GetSchoolDepartments(int schoolId)
        {
            return _context.Departments.Where(x => x.SchoolId == schoolId);
        }
    }
}
