using System;
using System.Collections.Generic;
using System.Text;
using TinyCollege.Data.Interfaces.IMotorPool;

namespace TinyCollege.Data.Models.MotorPool
{
    public class PartUsage: IPartUsage
    {
        public int PartUsageId { get; set; }
        public int Count { get; set; }

        public int PartId { get; set; }
        public Part Part { get; set; }

        public int MaintenanceDetailId { get; set; }
        public MaintenanceDetail MaintenanceDetail { get; set; }
    }
}