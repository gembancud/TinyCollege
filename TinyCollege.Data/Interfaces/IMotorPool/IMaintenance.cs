using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Interfaces.IMotorPool
{
    public interface IMaintenance
    {
         int MaintenanceId { get; set; }
         string Type { get; set; }
         DateTime CompletionDate { get; set; }

         int? ReleasingMechanicId { get; set; }

         int VehicleId { get; set; }

         int? ReportId { get; set; }
    }
}
