using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Models.MotorPool
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Name { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}