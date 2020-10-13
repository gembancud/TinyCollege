using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TinyCollege.Data.Models;

namespace TinyCollege.Service.Services
{
    public class SectionService : BaseService
    {
        public SectionService() : base()
        {
        }

        public List<Section> GetSections()
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Sections.ToList();
        }

        public List<Section> GetSections(string query)
        {
            var stringProperties = typeof(Section).GetProperties().Where(prop =>
                prop.PropertyType == typeof(string) ||
                prop.PropertyType == typeof(int) ||
                prop.PropertyType == typeof(int?)
            );

            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Sections.Where(
                delegate (Section x)
                {
                    return stringProperties.Any(prop => (prop.PropertyType == typeof(int) && prop.GetValue(x)?.ToString() == query) ||
                                                        (prop.PropertyType == typeof(int?) && prop.GetValue(x)?.ToString() == query) ||
                                                        (prop.PropertyType == typeof(string) && EF.Functions.Like(prop.GetValue(x)?.ToString(), $"%{query}%")));
                }
            ).ToList();
        }

        public List<Section> CreateSection(Section section)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            _context.Add(section);
            _context.SaveChanges();
            return _context.Sections.Where(x => x.SectionId == _context.Sections.Max(x => x.SectionId)).ToList();
        }

        public List<Schedule> GetSectionSchedule(int sectionScheduleId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Schedules.Where(x => x.ScheduleId == sectionScheduleId).ToList();
        }

        public List<Professor> GetSectionProfessor(int sectionProfessorId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Professors.Where(x => x.ProfessorId == sectionProfessorId).ToList();
        }

        public List<Course> GetSectionCourse(int sectionCourseId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Courses.Where(x => x.CourseId == sectionCourseId).ToList();
        }

        public List<Enrollment> GetSectionEnrollments(int sectionId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Enrollments.Where(x => x.SectionId == sectionId).ToList();
        }

        public List<Section> DeleteSection(Section section)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            try
            {
                _context.Sections.Attach(section);
                _context.Sections.Remove(section);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // ignored
            }

            return _context.Sections.ToList();
        }

        public List<Section> EditSection(Section section)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            var tmpSection = _context.Sections.First(x => x.SectionId == section.SectionId);
            _context.Entry(tmpSection).CurrentValues.SetValues(section);
            _context.SaveChanges();
            return _context.Sections.Where(x => x.SectionId == section.SectionId).ToList();
        }
    }
}
