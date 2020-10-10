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

        public IQueryable<Report> GetReports()
        {
            return _context.Reports;
        }

        public IQueryable<Maintenance> GetReportMaintenances(int reportId)
        {
            return _context.Maintenances.Where(x => x.ReportId == reportId);
        }

        public IQueryable<Reservation> GetReportReservations(int reportId)
        {
            return _context.Reservations.Where(x => x.ReportId == reportId);
        }

    }
}
