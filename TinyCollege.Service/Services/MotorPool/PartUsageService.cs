using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Service.Services.MotorPool
{
    public class PartUsageService : BaseService
    {
        public PartUsageService() : base()
        {
        }

        public IQueryable<PartUsage> GetPartUsages()
        {
            return _context.PartUsages;
        }
    }
}
