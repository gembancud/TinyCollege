using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Models.MotorPool
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Destination { get; set; }
        public int Billing { get; set; }
        public int Mileage { get; set; }

        public int? CheckoutFormId { get; set; }
        public Form? CheckoutForm { get; set; }

        public int? CompletionFormId { get; set; }
        public Form? CompletionForm { get; set; }

        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public int? ReportId { get; set; }
        public Report? Report { get; set; }
    }
}