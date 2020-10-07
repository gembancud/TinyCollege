﻿using System;
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
    }
}
