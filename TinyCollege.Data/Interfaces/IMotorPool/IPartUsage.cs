using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Interfaces.IMotorPool
{
    public interface IPartUsage
    {
        int PartUsageId { get; set; }
        int Count { get; set; }

        int PartId { get; set; }

        int MaintenanceDetailId { get; set; }
    }
}
