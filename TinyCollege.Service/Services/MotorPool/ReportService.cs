using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TinyCollege.Data.Models;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Service.Services.MotorPool
{
    public class ReportService : BaseService
    {
        public ReportService() : base()
        {
        }

        public List<Report> GetReports()
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Reports.ToList();
        }

        public List<Report> GetReports(string query)
        {
            var stringProperties = typeof(Report).GetProperties().Where(prop =>
                prop.PropertyType == typeof(string) ||
                prop.PropertyType == typeof(int) ||
                prop.PropertyType == typeof(int?)
            );

            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Reports.Where(
                delegate (Report x)
                {
                    return stringProperties.Any(prop => (prop.PropertyType == typeof(int) && prop.GetValue(x)?.ToString() == query) ||
                                                        (prop.PropertyType == typeof(int?) && prop.GetValue(x)?.ToString() == query) ||
                                                        (prop.PropertyType == typeof(string) && EF.Functions.Like(prop.GetValue(x)?.ToString(), $"%{query}%")));
                }
            ).ToList();
        }

        public List<Report> CreateReport(Report report)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            _context.Add(report);
            _context.SaveChanges();
            return _context.Reports.Where(x => x.ReportId == _context.Reports.Max(x => x.ReportId)).ToList();
        }

        public List<Maintenance> GetReportMaintenances(int reportId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Maintenances.Where(x => x.ReportId == reportId).ToList();
        }

        public List<Reservation> GetReportReservations(int reportId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Reservations.Where(x => x.ReportId == reportId).ToList();
        }

        public List<Report> DeleteReport(Report report)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

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

            return _context.Reports.ToList();
        }

        public List<Report> EditReport(Report report)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            var tmpReport = _context.Reports.First(x => x.ReportId == report.ReportId);
            _context.Entry(tmpReport).CurrentValues.SetValues(report);
            _context.SaveChanges();
            return _context.Reports.Where(x => x.ReportId == report.ReportId).ToList();
        }

    }
}
