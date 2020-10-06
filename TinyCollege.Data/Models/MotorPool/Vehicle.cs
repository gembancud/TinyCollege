using System;
using System.Collections.Generic;
using System.Text;
using TinyCollege.Data.Interfaces.IMotorPool;

namespace TinyCollege.Data.Models.MotorPool
{
    public class Vehicle: IVehicle
    {
        public int VehicleId { get; set; }
        public string Type { get; set; }
        public int SeatingCapacity { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}