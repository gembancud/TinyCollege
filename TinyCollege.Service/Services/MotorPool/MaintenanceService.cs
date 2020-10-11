using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Service.Services.MotorPool
{
    public class MaintenanceService : BaseService
    {
        public MaintenanceService() : base()
        {
        }

        public IQueryable<Maintenance> GetMaintenances()
        {
            return _context.Maintenances;
        }

        public IQueryable<Maintenance> CreateMaintenance(Maintenance maintenance)
        {
            _context.Add(maintenance);
            _context.SaveChanges();
            return _context.Maintenances.Where(x => x.MaintenanceId == _context.Maintenances.Max(x => x.MaintenanceId));
        }

        public IQueryable<Employee> GetMaintenanceReleasingMechanic(int maintenanceEmployeeId)
        {
            return _context.Employees.Where(x => x.EmployeeId == maintenanceEmployeeId);
        }

        public IQueryable<Vehicle> GetMaintenanceVehicle(int maintenanceVehicleId)
        {
            return _context.Vehicles.Where(x => x.VehicleId == maintenanceVehicleId);
        }

        public IQueryable<Report> GetMaintenanceReport(int maintenanceReportId)
        {
            return _context.Reports.Where(x => x.ReportId == maintenanceReportId);
        }

        public IQueryable<MaintenanceDetail> GetMaintenanceMaintenanceDetails(int maintenanceId)
        {
            return _context.MaintenanceDetails.Where(x => x.MaintenanceId == maintenanceId);
        }

        public IQueryable<Maintenance> DeleteMaintenance(Maintenance maintenance)
        {
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

            return _context.Maintenances;
        }
    }
}
