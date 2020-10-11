using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models;

namespace TinyCollege.Service.Services
{
    public class TenureService : BaseService
    {
        public TenureService() : base()
        {
        }

        public IQueryable<Tenure> GetTenures()
        {
            return _context.Tenures;
        }

        public IQueryable<Tenure> CreateTenure(Tenure tenure)
        {
            _context.Add(tenure);
            _context.SaveChanges();
            return _context.Tenures.Where(x => x.TenureId == _context.Tenures.Max(x => x.TenureId));
        }

        public IQueryable<Professor> GetTenureProfessor(int tenureProfessorId)
        {
            return _context.Professors.Where(x => x.ProfessorId == tenureProfessorId);
        }

        public IQueryable<Department> GetTenureDepartment(int tenureDepartmentId)
        {
            return _context.Departments.Where(x => x.DepartmentId == tenureDepartmentId);
        }

        public IQueryable<Tenure> DeleteTenure(Tenure tenure)
        {
            try
            {
                _context.Tenures.Attach(tenure);
                _context.Tenures.Remove(tenure);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // ignored
            }

            return _context.Tenures;
        }
    }
}
