﻿using System;
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

        public IQueryable<Part> GetPartUsagePart(int partUsagePartId)
        {
            return _context.Parts.Where(x => x.PartId == partUsagePartId);
        }

        public IQueryable<MaintenanceDetail> GetPartUsageMaintenanceDetail(int partUsageMaintenanceDetailId)
        {
            return _context.MaintenanceDetails.Where(x => x.MaintenanceDetailId == partUsageMaintenanceDetailId);
        }
    }
}
