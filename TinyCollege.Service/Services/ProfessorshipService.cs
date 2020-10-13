using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TinyCollege.Data.Models;

namespace TinyCollege.Service.Services
{
    public class ProfessorshipService : BaseService
    {
        public ProfessorshipService() : base()
        {
        }

        public List<Professorship> GetProfessorships()
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Professorships.ToList();
        }

        public List<Professorship> GetProfessorships(string query)
        {
            var stringProperties = typeof(Professorship).GetProperties().Where(prop =>
                prop.PropertyType == typeof(string) ||
                prop.PropertyType == typeof(int) ||
                prop.PropertyType == typeof(int?)
            );

            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Professorships.Where(
                delegate (Professorship x)
                {
                    return stringProperties.Any(prop => (prop.PropertyType == typeof(int) && prop.GetValue(x)?.ToString() == query) ||
                                                        (prop.PropertyType == typeof(int?) && prop.GetValue(x)?.ToString() == query) ||
                                                        (prop.PropertyType == typeof(string) && EF.Functions.Like(prop.GetValue(x)?.ToString(), $"%{query}%")));
                }
            ).ToList();
        }

        public List<Professorship> CreateProfessorship(Professorship vehicle)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            _context.Add(vehicle);
            _context.SaveChanges();
            return _context.Professorships.Where(x => x.ProfessorShipId == _context.Professorships.Max(x => x.ProfessorShipId)).ToList();
        }

        public List<Professor> GetProfessorshipProfessor(int professorshipProfessorId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Professors.Where(x => x.ProfessorId == professorshipProfessorId).ToList();
        }

        public List<Department> GetProfessorshipDepartment(int professorshipDepartmentId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Departments.Where(x => x.DepartmentId == professorshipDepartmentId).ToList();
        }

        public List<Professorship> DeleteProfessorship(Professorship professorship)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            try
            {
                _context.Professorships.Attach(professorship);
                _context.Professorships.Remove(professorship);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // ignored
            }

            return _context.Professorships.ToList();
        }

        public List<Professorship> EditProfessorship(Professorship professorship)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            var tmpProfessorship = _context.Professorships.First(x => x.ProfessorShipId == professorship.ProfessorShipId);
            _context.Entry(tmpProfessorship).CurrentValues.SetValues(professorship);
            _context.SaveChanges();
            return _context.Professorships.Where(x => x.ProfessorShipId == professorship.ProfessorShipId).ToList();
        }
    }
}
