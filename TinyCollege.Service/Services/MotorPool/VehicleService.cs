using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TinyCollege.Data.Models;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Service.Services.MotorPool
{
    public class VehicleService : BaseService
    {
        public VehicleService() : base()
        {
        }

        public List<Vehicle> GetVehicles()
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Vehicles.ToList();
        }

        public List<Vehicle> GetVehicles(string query)
        {
            var stringProperties = typeof(Vehicle).GetProperties().Where(prop =>
                prop.PropertyType == typeof(string) ||
                prop.PropertyType == typeof(int) ||
                prop.PropertyType == typeof(int?)
            );

            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Vehicles.Where(
                delegate (Vehicle x)
                {
                    return stringProperties.Any(prop => (prop.PropertyType == typeof(int) && prop.GetValue(x)?.ToString() == query) ||
                                                        (prop.PropertyType == typeof(int?) && prop.GetValue(x)?.ToString() == query) ||
                                                        (prop.PropertyType == typeof(string) && EF.Functions.Like(prop.GetValue(x)?.ToString(), $"%{query}%")));
                }
            ).ToList();
        }

        public List<Vehicle> CreateVehicle(Vehicle vehicle)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            _context.Add(vehicle);
            _context.SaveChanges();
            return _context.Vehicles.Where(x => x.VehicleId == _context.Vehicles.Max(x => x.VehicleId)).ToList();
        }

        public List<Reservation> GetVehicleReservations(int vehicleId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Reservations.Where(x => x.VehicleId == vehicleId).ToList();
        }

        public List<Vehicle> DeleteVehicle(Vehicle vehicle)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            try
            {
                _context.Vehicles.Attach(vehicle);
                _context.Vehicles.Remove(vehicle);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // ignored
            }

            return _context.Vehicles.ToList();
        }

        public List<Vehicle> EditVehicle(Vehicle vehicle)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            var tmpVehicle = _context.Vehicles.First(x => x.VehicleId == vehicle.VehicleId);
            _context.Entry(tmpVehicle).CurrentValues.SetValues(vehicle);
            _context.SaveChanges();
            return _context.Vehicles.Where(x => x.VehicleId == vehicle.VehicleId).ToList();
        }
    }
}
