﻿using System;
using System.Collections.Generic;
using System.Text;
using TinyCollege.Data.Interfaces.IMotorPool;

namespace TinyCollege.Data.Models.MotorPool
{
    public class Reservation: IReservation
    {
        public int ReservationId { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Destination { get; set; }
        public int Billing { get; set; }
        public int Mileage { get; set; }

        public ICollection<ReservationForm> ReservationForms { get; set; }

        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public int? ReportId { get; set; }
        public Report Report { get; set; }
    }
}