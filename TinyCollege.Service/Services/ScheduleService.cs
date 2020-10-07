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
    }
}
