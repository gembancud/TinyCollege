using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Service.Services.MotorPool
{
    public class MaintenanceDetailService : BaseService
    {
        public MaintenanceDetailService() : base()
        {
        }

        public IQueryable<MaintenanceDetail> GetMaintenanceDetails()
        {
            return _context.MaintenanceDetails;
        }

        public IQueryable<MaintenanceDetail> CreateMaintenanceDetail(MaintenanceDetail maintenanceDetail)
        {
            _context.Add(maintenanceDetail);
            _context.SaveChanges();
            return _context.MaintenanceDetails.Where(x => x.MaintenanceDetailId == _context.MaintenanceDetails.Max(x => x.MaintenanceDetailId));
        }

        public IQueryable<Maintenance> GetMaintenanceDetailMaintenance(int maintenanceId)
        {
            return _context.Maintenances.Where(x => x.MaintenanceId== maintenanceId);
        }

        public IQueryable<PartUsage> GetMaintenanceDetailPartUsages(int maintenanceDetailId)
        {
            return _context.PartUsages.Where(x => x.MaintenanceDetailId == maintenanceDetailId);
        }

        public IQueryable<Employee> GetMaintenanceDetailEmployee(int employeeId)
        {
            return _context.Employees.Where(x => x.EmployeeId == employeeId);
        }

        public IQueryable<MaintenanceDetail> DeleteMaintenanceDetail(MaintenanceDetail maintenanceDetail)
        {
            try
            {
                _context.MaintenanceDetails.Attach(maintenanceDetail);
                _context.MaintenanceDetails.Remove(maintenanceDetail);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // ignored
            }

            return _context.MaintenanceDetails;
        }
    }
}
