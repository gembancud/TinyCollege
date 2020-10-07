using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
