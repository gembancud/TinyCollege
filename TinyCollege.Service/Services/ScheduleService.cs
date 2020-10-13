using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TinyCollege.Data.Models;

namespace TinyCollege.Service.Services
{
    public class ScheduleService : BaseService
    {
        public ScheduleService() : base()
        {
        }

        public List<Schedule> GetSchedules()
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Schedules.ToList();
        }

        public List<Schedule> GetSchedules(string query)
        {
            var stringProperties = typeof(Schedule).GetProperties().Where(prop =>
                prop.PropertyType == typeof(string) ||
                prop.PropertyType == typeof(int) ||
                prop.PropertyType == typeof(int?)
            );

            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Schedules.Where(
                delegate (Schedule x)
                {
                    return stringProperties.Any(prop => (prop.PropertyType == typeof(int) && prop.GetValue(x)?.ToString() == query) ||
                                                        (prop.PropertyType == typeof(int?) && prop.GetValue(x)?.ToString() == query) ||
                                                        (prop.PropertyType == typeof(string) && EF.Functions.Like(prop.GetValue(x)?.ToString(), $"%{query}%")));
                }
            ).ToList();
        }

        public List<Schedule> CreateSchedule(Schedule schedule)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            _context.Add(schedule);
            _context.SaveChanges();
            return _context.Schedules.Where(x => x.ScheduleId == _context.Schedules.Max(x => x.ScheduleId)).ToList();
        }

        public List<Section> GetScheduleSection(int scheduleSectionId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Sections.Where(x => x.SectionId == scheduleSectionId).ToList();
        }

        public List<Schedule> DeleteSchedule(Schedule schedule)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

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

            return _context.Schedules.ToList();
        }

        public List<Schedule> EditSchedule(Schedule schedule)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            var tmpSchedule = _context.Schedules.First(x => x.ScheduleId == schedule.ScheduleId);
            _context.Entry(tmpSchedule).CurrentValues.SetValues(schedule);
            _context.SaveChanges();
            return _context.Schedules.Where(x => x.ScheduleId == schedule.ScheduleId).ToList();
        }
    }
}
