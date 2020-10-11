using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Service.Services.MotorPool
{
    public class VehicleService : BaseService
    {
        public VehicleService() : base()
        {
        }

        public IQueryable<Vehicle> GetVehicles()
        {
            return _context.Vehicles;
        }

        public IQueryable<Vehicle> CreateVehicle(Vehicle vehicle)
        {
            _context.Add(vehicle);
            _context.SaveChanges();
            return _context.Vehicles.Where(x => x.VehicleId == _context.Vehicles.Max(x => x.VehicleId));
        }

        public IQueryable<Reservation> GetVehicleReservations(int vehicleId)
        {
            return _context.Reservations.Where(x => x.VehicleId == vehicleId);
        }
    }
}
