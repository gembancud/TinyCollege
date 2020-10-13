using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TinyCollege.Data.Models;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Service.Services
{
    public class ProfessorService : BaseService
    {
        public ProfessorService() : base()
        {
        }

        public List<Professor> GetProfessors()
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Professors.ToList();
        }

        public List<Professor> GetProfessors(string query)
        {
            var stringProperties = typeof(Professor).GetProperties().Where(prop =>
                prop.PropertyType == typeof(string) ||
                prop.PropertyType == typeof(int) ||
                prop.PropertyType == typeof(int?)
            );

            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Professors.Where(
                delegate (Professor x)
                {
                    return stringProperties.Any(prop => (prop.PropertyType == typeof(int) && prop.GetValue(x)?.ToString() == query) ||
                                                        (prop.PropertyType == typeof(int?) && prop.GetValue(x)?.ToString() == query) ||
                                                        (prop.PropertyType == typeof(string) && EF.Functions.Like(prop.GetValue(x)?.ToString(), $"%{query}%")));
                }
            ).ToList();
        }

        public List<Professor> CreateProfessor(Professor professor)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            _context.Add(professor);
            _context.SaveChanges();
            return _context.Professors.Where(x => x.ProfessorId == _context.Professors.Max(x => x.ProfessorId)).ToList();
        }

        public List<Professorship> GetProfessorProfessorships(int professorId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Professorships.Where(x => x.ProfessorId == professorId).ToList();
        }

        public List<Section> GetProfessorSections(int professorId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Sections.Where(x => x.ProfessorId == professorId).ToList();
        }

        public List<Advisory> GetProfessorAdvisories(int professorId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Advisories.Where(x => x.ProfessorId == professorId).ToList();
        }

        public List<Reservation> GetProfessorReservations(int professorId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Reservations.Where(x => x.ProfessorId == professorId).ToList();
        }

        public List<Tenure> GetProfessorTenures(int professorId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Tenures.Where(x => x.ProfessorId == professorId).ToList();
        }

        public List<ProfessorContract> GetProfessorProfessorContracts(int professorId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.ProfessorContracts.Where(x => x.ProfessorId == professorId).ToList();
        }

        public List<Professor> DeleteProfessor(Professor professor)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            try
            {
                _context.Professors.Attach(professor);
                _context.Professors.Remove(professor);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // ignored
            }

            return _context.Professors.ToList();
        }

        public List<Professor> EditProfessor(Professor professor)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            var tmpProfessor = _context.Professors.First(x => x.ProfessorId == professor.ProfessorId);
            _context.Entry(tmpProfessor).CurrentValues.SetValues(professor);
            _context.SaveChanges();
            return _context.Professors.Where(x => x.ProfessorId == professor.ProfessorId).ToList();
        }
    }
}
