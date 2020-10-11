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

        public IQueryable<Report> CreateReport(Report report)
        {
            _context.Add(report);
            _context.SaveChanges();
            return _context.Reports.Where(x => x.ReportId == _context.Reports.Max(x => x.ReportId));
        }

        public IQueryable<Maintenance> GetReportMaintenances(int reportId)
        {
            return _context.Maintenances.Where(x => x.ReportId == reportId);
        }

        public IQueryable<Reservation> GetReportReservations(int reportId)
        {
            return _context.Reservations.Where(x => x.ReportId == reportId);
        }

        public IQueryable<Report> DeleteReport(Report report)
        {
            try
            {
                _context.Reports.Attach(report);
                _context.Reports.Remove(report);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // ignored
            }

            return _context.Reports;
        }

    }
}
