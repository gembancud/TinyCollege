using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Service.Services
{
    public class AdvisoryService : BaseService
    {
        public AdvisoryService() : base()
        {
        }

        public IQueryable<Advisory> GetAdvisories()
        {
            return _context.Advisories;
        }
    }
}
