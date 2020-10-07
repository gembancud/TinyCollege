using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models;

namespace TinyCollege.Service.Services
{
    public class SchoolService : BaseService
    {
        public SchoolService() : base()
        {
        }

        public IQueryable<School> GetSchools()
        {
            return _context.Schools;
        }
    }
}
