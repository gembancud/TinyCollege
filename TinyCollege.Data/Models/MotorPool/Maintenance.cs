using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Models.MotorPool
{
    public class Maintenance
    {
        public int MaintenanceId { get; set; }
        public string Type { get; set; }
        public DateTime CompletionDate { get; set; }

        public int? LogFormId { get; set; }
        public Form? LogForm { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public int? ReportId { get; set; }
        public Report? Report { get; set; }
    }
}