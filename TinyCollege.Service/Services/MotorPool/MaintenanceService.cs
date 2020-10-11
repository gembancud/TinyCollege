using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Service.Services.MotorPool
{
    public class MaintenanceService : BaseService
    {
        public MaintenanceService() : base()
        {
        }

        public List<Maintenance> GetMaintenances()
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Maintenances.ToList();
        }

        public List<Maintenance> CreateMaintenance(Maintenance maintenance)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            _context.Add(maintenance);
            _context.SaveChanges();
            return _context.Maintenances.Where(x => x.MaintenanceId == _context.Maintenances.Max(x => x.MaintenanceId)).ToList();
        }

        public List<Employee> GetMaintenanceReleasingMechanic(int maintenanceEmployeeId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Employees.Where(x => x.EmployeeId == maintenanceEmployeeId).ToList();
        }

        public List<Vehicle> GetMaintenanceVehicle(int maintenanceVehicleId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Vehicles.Where(x => x.VehicleId == maintenanceVehicleId).ToList();
        }

        public List<Report> GetMaintenanceReport(int maintenanceReportId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Reports.Where(x => x.ReportId == maintenanceReportId).ToList();
        }

        public List<MaintenanceDetail> GetMaintenanceMaintenanceDetails(int maintenanceId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.MaintenanceDetails.Where(x => x.MaintenanceId == maintenanceId).ToList();
        }

        public List<Maintenance> DeleteMaintenance(Maintenance maintenance)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            try
            {
                _context.Maintenances.Attach(maintenance);
                _context.Maintenances.Remove(maintenance);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // ignored
            }

            return _context.Maintenances.ToList();
        }

        public List<Maintenance> EditMaintenance(Maintenance maintenance)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            var tmpMaintenance = _context.Maintenances.First(x => x.MaintenanceId == maintenance.MaintenanceId);
            _context.Entry(tmpMaintenance).CurrentValues.SetValues(maintenance);
            _context.SaveChanges();
            return _context.Maintenances.Where(x => x.MaintenanceId == maintenance.MaintenanceId).ToList();
        }
    }
}
