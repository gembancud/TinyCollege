using System;
using System.Collections.Generic;
using System.Text;
using TinyCollege.Data.Interfaces.IMotorPool;

namespace TinyCollege.Data.Models.MotorPool
{
    public class MaintenanceDetail: IMaintenanceDetail
    {
        public int MaintenanceDetailId { get; set; }
        public DateTime ProcessingDate { get; set; }

        public int MaintenanceId { get; set; }
        public Maintenance Maintenance { get; set; }

        public ICollection<PartUsage> PartUsages { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}