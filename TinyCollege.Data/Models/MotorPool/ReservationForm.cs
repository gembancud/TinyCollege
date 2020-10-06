using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Constraints;
using TinyCollege.Data.Interfaces.IMotorPool;

namespace TinyCollege.Data.Models.MotorPool
{
    public class ReservationForm: IReservationForm
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