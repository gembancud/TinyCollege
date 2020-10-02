using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Models.MotorPool
{
    public class Report
    {
        public int ReportId { get; set; }
        public DateTime Month { get; set; }
        public string Type { get; set; }

        public ICollection<Maintenance>? Maintenances { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
    }
}