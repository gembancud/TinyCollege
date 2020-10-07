using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Service.Services.MotorPool
{
    public class ReportService : BaseService
    {
        public ReportService() : base()
        {
        }

        public IQueryable<Report> GetReportsPartUsages()
        {
            return _context.Reports;
        }
    }
}
