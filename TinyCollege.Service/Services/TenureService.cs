using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models;

namespace TinyCollege.Service.Services
{
    public class TenureService : BaseService
    {
        public TenureService() : base()
        {
        }

        public IQueryable<Tenure> GetTenures()
        {
            return _context.Tenures;
        }
    }
}
