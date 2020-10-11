using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models;

namespace TinyCollege.Service.Services
{
    public class ScheduleService : BaseService
    {
        public ScheduleService() : base()
        {
        }

        public IQueryable<Schedule> GetSchedules()
        {
            return _context.Schedules;
        }

        public IQueryable<Schedule> CreateSchedule(Schedule schedule)
        {
            _context.Add(schedule);
            _context.SaveChanges();
            return _context.Schedules.Where(x => x.ScheduleId == _context.Schedules.Max(x => x.ScheduleId));
        }

        public IQueryable<Section> GetScheduleSection(int scheduleSectionId)
        {
            return _context.Sections.Where(x => x.SectionId == scheduleSectionId);
        }

        public IQueryable<Schedule> DeleteSchedule(Schedule schedule)
        {
            try
            {
                _context.Schedules.Attach(schedule);
                _context.Schedules.Remove(schedule);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // ignored
            }

            return _context.Schedules;
        }
    }
}
