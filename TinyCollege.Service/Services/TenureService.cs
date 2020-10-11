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

        public List<Tenure> GetTenures()
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Tenures.ToList();
        }

        public List<Tenure> CreateTenure(Tenure tenure)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            _context.Add(tenure);
            _context.SaveChanges();
            return _context.Tenures.Where(x => x.TenureId == _context.Tenures.Max(x => x.TenureId)).ToList();
        }

        public List<Professor> GetTenureProfessor(int tenureProfessorId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Professors.Where(x => x.ProfessorId == tenureProfessorId).ToList();
        }

        public List<Department> GetTenureDepartment(int tenureDepartmentId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Departments.Where(x => x.DepartmentId == tenureDepartmentId).ToList();
        }

        public List<Tenure> DeleteTenure(Tenure tenure)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

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

            return _context.Tenures.ToList();
        }

        public List<Tenure> EditTenure(Tenure tenure)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            var tmpTenure = _context.Tenures.First(x => x.TenureId == tenure.TenureId);
            _context.Entry(tmpTenure).CurrentValues.SetValues(tenure);
            _context.SaveChanges();
            return _context.Tenures.Where(x => x.TenureId == tenure.TenureId).ToList();
        }
    }
}
