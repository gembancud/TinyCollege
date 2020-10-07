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
    }
}
