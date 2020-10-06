using System;
using System.Collections.Generic;
using System.Text;
using TinyCollege.Data.Interfaces.IMotorPool;

namespace TinyCollege.Data.Models.MotorPool
{
    public class Maintenance: IMaintenance
    {
        public int MaintenanceId { get; set; }
        public string Type { get; set; }
        public DateTime CompletionDate { get; set; }

        public ICollection<MaintenanceDetail> MaintenanceDetails { get; set; }

        public int? ReleasingMechanicId { get; set; }
        public Employee ReleasingMechanic { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public int? ReportId { get; set; }
        public Report Report { get; set; }
    }
}