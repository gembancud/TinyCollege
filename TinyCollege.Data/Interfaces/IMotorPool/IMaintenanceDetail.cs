using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Interfaces.IMotorPool
{
    public interface IMaintenanceDetail
    {
         int MaintenanceDetailId { get; set; }
         DateTime ProcessingDate { get; set; }

         int MaintenanceId { get; set; }

         int EmployeeId { get; set; }
    }
}
