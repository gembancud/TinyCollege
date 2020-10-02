using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Constraints;

namespace TinyCollege.Data.Models.MotorPool
{
    public class Form
    {
        public int FormId { get; set; }
        public string Type { get; set; }
        public string Notes { get; set; }
        public DateTime SubmissionDate { get; set; }

        public int? ReservationId { get; set; }
        public Reservation? Reservation { get; set; }

        public int? MaintenanceId { get; set; }
        public Maintenance? Maintenance { get; set; }

        public ICollection<PartUsage>? PartUsages { get; set; }

        public int? PrevFormId { get; set; }
        public Form? PrevForm { get; set; }

        public int? NextFormId { get; set; }
        public Form? NextForm { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}