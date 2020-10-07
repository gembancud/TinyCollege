using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models;

namespace TinyCollege.Service.Services
{
    public class DepartmentService : BaseService
    {
        public DepartmentService() : base()
        {
        }

        public IQueryable<Department> GetDepartments()
        {
            return _context.Departments;
        }
    }
}
