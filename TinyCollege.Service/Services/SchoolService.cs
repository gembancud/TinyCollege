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

        public List<School> GetSchools()
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Schools.ToList();
        }

        public List<School> CreateSchool(School school)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            _context.Add(school);
            _context.SaveChanges();
            return _context.Schools.Where(x => x.SchoolId == _context.Schools.Max(x => x.SchoolId)).ToList();
        }

        public List<Professor> GetSchoolDean(int schoolProfessorId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Professors.Where(x => x.ProfessorId == schoolProfessorId).ToList();
        }

        public List<Department> GetSchoolDepartments(int schoolId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Departments.Where(x => x.SchoolId == schoolId).ToList();
        }

        public List<School> DeleteSchool(School school)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            try
            {
                _context.Schools.Attach(school);
                _context.Schools.Remove(school);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // ignored
            }

            return _context.Schools.ToList();
        }

        public List<School> EditSchool(School school)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            var tmpSchool = _context.Schools.First(x => x.SchoolId == school.SchoolId);
            _context.Entry(tmpSchool).CurrentValues.SetValues(school);
            _context.SaveChanges();
            return _context.Schools.Where(x => x.SchoolId == school.SchoolId).ToList();
        }
    }
}
