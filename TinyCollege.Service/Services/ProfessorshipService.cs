using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models;

namespace TinyCollege.Service.Services
{
    public class ProfessorshipService : BaseService
    {
        public ProfessorshipService() : base()
        {
        }

        public IQueryable<Professorship> GetProfessorships()
        {
            return _context.Professorships;
        }

        public IQueryable<Professor> GetProfessorshipProfessor(int professorshipProfessorId)
        {
            return _context.Professors.Where(x => x.ProfessorId == professorshipProfessorId);
        }

        public IQueryable<Department> GetProfessorshipDepartment(int professorshipDepartmentId)
        {
            return _context.Departments.Where(x => x.DepartmentId == professorshipDepartmentId);
        }
    }
}
