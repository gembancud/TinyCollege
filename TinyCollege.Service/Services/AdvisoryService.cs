using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TinyCollege.Data.Models;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Service.Services
{
    public class AdvisoryService : BaseService
    {
        public AdvisoryService() : base()
        {
        }

        public List<Advisory> GetAdvisories()
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Advisories.ToList();
        }

        public List<Advisory> GetAdvisories(string query)
        {
            var stringProperties = typeof(Advisory).GetProperties().Where(prop =>
                prop.PropertyType == typeof(string) ||
                prop.PropertyType == typeof(int) ||
                prop.PropertyType == typeof(int?)
            );

            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Advisories.Where(
                delegate (Advisory x)
                {
                    return stringProperties.Any(prop => (prop.PropertyType == typeof(int) && prop.GetValue(x)?.ToString() == query) ||
                                                        (prop.PropertyType == typeof(int?) && prop.GetValue(x)?.ToString() == query) ||
                                                        (prop.PropertyType == typeof(string) && EF.Functions.Like(prop.GetValue(x)?.ToString(), $"%{query}%")));
                }
            ).ToList();
        }

        public List<Advisory> CreateAdvisory(Advisory advisory)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            _context.Add(advisory);
            _context.SaveChanges();
            return _context.Advisories.Where(x => x.AdvisoryId == _context.Advisories.Max(x => x.AdvisoryId)).ToList();
        }

        public List<Department> GetAdvisoryDepartment(int advisoryDepartmentId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Departments.Where(x => x.DepartmentId == advisoryDepartmentId).ToList();
        }

        public List<Professor> GetAdvisoryProfessor(int advisoryProfessorId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Professors.Where(x => x.ProfessorId == advisoryProfessorId).ToList();
        }

        public List<Student> GetAdvisoryStudent(int advisoryStudentId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Students.Where(x => x.StudentId == advisoryStudentId).ToList();
        }

        public List<Advisory> DeleteAdvisory(Advisory advisory)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            try
            {
                _context.Advisories.Attach(advisory);
                _context.Advisories.Remove(advisory);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // ignored
            }

            return _context.Advisories.ToList();
        }

        public List<Advisory> EditAdvisory(Advisory advisory)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            var tmpAdvisory = _context.Advisories.First(x => x.AdvisoryId == advisory.AdvisoryId);
            _context.Entry(tmpAdvisory).CurrentValues.SetValues(advisory);
            _context.SaveChanges();
            return _context.Advisories.Where(x => x.AdvisoryId == advisory.AdvisoryId).ToList();
        }
    }
}
