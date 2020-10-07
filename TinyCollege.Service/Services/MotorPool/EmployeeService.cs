using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Service.Services.MotorPool
{
    public class EmployeeService : BaseService
    {
        public EmployeeService() : base()
        {
        }

        public IQueryable<Employee> GetEmployees()
        {
            return _context.Employees;
        }
    }
}
