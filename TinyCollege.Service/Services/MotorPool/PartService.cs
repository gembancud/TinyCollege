﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Service.Services.MotorPool
{
    public class PartService : BaseService
    {
        public PartService() : base()
        {
        }

        public IQueryable<Part> GetParts()
        {
            return _context.Parts;
        }
    }
}