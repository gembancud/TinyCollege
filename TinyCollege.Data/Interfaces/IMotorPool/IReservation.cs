using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Interfaces.IMotorPool
{
    public interface IReservation
    {
        public int ReservationId { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Destination { get; set; }
        public int Billing { get; set; }
        public int Mileage { get; set; }

        public int ProfessorId { get; set; }

        public int VehicleId { get; set; }

        public int? ReportId { get; set; }
    }
}
