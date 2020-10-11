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

        public IQueryable<Professorship> CreateProfessorship(Professorship vehicle)
        {
            _context.Add(vehicle);
            _context.SaveChanges();
            return _context.Professorships.Where(x => x.ProfessorShipId == _context.Professorships.Max(x => x.ProfessorShipId));
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
