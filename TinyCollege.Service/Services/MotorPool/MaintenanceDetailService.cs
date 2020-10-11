using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using TinyCollege.Data.Models;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Service.Services.MotorPool
{
    public class MaintenanceDetailService : BaseService
    {
        public MaintenanceDetailService() : base()
        {
        }

        public List<MaintenanceDetail> GetMaintenanceDetails()
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.MaintenanceDetails.ToList();
        }

        public List<MaintenanceDetail> CreateMaintenanceDetail(MaintenanceDetail maintenanceDetail)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            _context.Add(maintenanceDetail);
            _context.SaveChanges();
            return _context.MaintenanceDetails.Where(x => x.MaintenanceDetailId == _context.MaintenanceDetails.Max(x => x.MaintenanceDetailId)).ToList();
        }

        public List<Maintenance> GetMaintenanceDetailMaintenance(int maintenanceId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Maintenances.Where(x => x.MaintenanceId== maintenanceId).ToList();
        }

        public List<PartUsage> GetMaintenanceDetailPartUsages(int maintenanceDetailId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.PartUsages.Where(x => x.MaintenanceDetailId == maintenanceDetailId).ToList();
        }

        public List<Employee> GetMaintenanceDetailEmployee(int employeeId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Employees.Where(x => x.EmployeeId == employeeId).ToList();
        }

        public List<MaintenanceDetail> DeleteMaintenanceDetail(MaintenanceDetail maintenanceDetail)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

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

            return _context.MaintenanceDetails.ToList();
        }

        public List<MaintenanceDetail> EditMaintenanceDetail(MaintenanceDetail maintenanceDetail)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            var tmpMaintenanceDetail = _context.MaintenanceDetails.First(x => x.MaintenanceDetailId == maintenanceDetail.MaintenanceDetailId);
            _context.Entry(tmpMaintenanceDetail).CurrentValues.SetValues(maintenanceDetail);
            _context.SaveChanges();
            return _context.MaintenanceDetails.Where(x => x.MaintenanceDetailId == maintenanceDetail.MaintenanceDetailId).ToList();
        }
    }
}
