using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Constraints;

namespace TinyCollege.Data.Models.MotorPool
{
    public class ReservationForm
    {
        public int ReservationFormId { get; set; }
        public string Type { get; set; }
        public string Notes { get; set; }
        public DateTime SubmissionDate { get; set; }

        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}