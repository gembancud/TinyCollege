using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models;

namespace TinyCollege.Service.Services
{
    public class SectionService : BaseService
    {
        public SectionService() : base()
        {
        }

        public IQueryable<Section> GetSections()
        {
            return _context.Sections;
        }

        public IQueryable<Section> CreateSection(Section section)
        {
            _context.Add(section);
            _context.SaveChanges();
            return _context.Sections.Where(x => x.SectionId == _context.Sections.Max(x => x.SectionId));
        }

        public IQueryable<Schedule> GetSectionSchedule(int sectionScheduleId)
        {
            return _context.Schedules.Where(x => x.ScheduleId == sectionScheduleId);
        }

        public IQueryable<Professor> GetSectionProfessor(int sectionProfessorId)
        {
            return _context.Professors.Where(x => x.ProfessorId == sectionProfessorId);
        }

        public IQueryable<Course> GetSectionCourse(int sectionCourseId)
        {
            return _context.Courses.Where(x => x.CourseId == sectionCourseId);
        }

        public IQueryable<Enrollment> GetSectionEnrollments(int sectionId)
        {
            return _context.Enrollments.Where(x => x.SectionId == sectionId);
        }

        public IQueryable<Section> DeleteSection(Section section)
        {
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

            return _context.Sections;
        }
    }
}
