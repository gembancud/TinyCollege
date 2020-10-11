using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Service.Services
{
    public class ProfessorService : BaseService
    {
        public ProfessorService() : base()
        {
        }

        public IQueryable<Professor> GetProfessors()
        {
            return _context.Professors;
        }

        public IQueryable<Professorship> GetProfessorProfessorships(int professorId)
        {
            return _context.Professorships.Where(x => x.ProfessorId == professorId);
        }

        public IQueryable<Section> GetProfessorSections(int professorId)
        {
            return _context.Sections.Where(x => x.ProfessorId == professorId);
        }

        public IQueryable<Advisory> GetProfessorAdvisories(int professorId)
        {
            return _context.Advisories.Where(x => x.ProfessorId == professorId);
        }

        public IQueryable<Reservation> GetProfessorReservations(int professorId)
        {
            return _context.Reservations.Where(x => x.ProfessorId == professorId);
        }

        public IQueryable<Tenure> GetProfessorTenures(int professorId)
        {
            return _context.Tenures.Where(x => x.ProfessorId == professorId);
        }

        public IQueryable<ProfessorContract> GetProfessorProfessorContracts(int professorId)
        {
            return _context.ProfessorContracts.Where(x => x.ProfessorId == professorId);
        }
    }
}
