using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Interfaces.IMotorPool
{
    public interface IVehicle
    {
        int VehicleId { get; set; }
        string Type { get; set; }
        int SeatingCapacity { get; set; }

    }
}
