using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Models.MotorPool
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Type { get; set; }
        public int SeatingCapacity { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}