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

        public IQueryable<Employee> CreateEmployee(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
            return _context.Employees.Where(x => x.EmployeeId == employee.EmployeeId);
        }

        public IQueryable<ReservationForm> GetEmployeeReservationForms(int employeeId)
        {
            return _context.ReservationForms.Where(x => x.EmployeeId == employeeId);
        }

        public IQueryable<MaintenanceDetail> GetEmployeeMaintenanceDetails(int employeeId)
        {
            return _context.MaintenanceDetails.Where(x => x.EmployeeId == employeeId);
        }
    }
}
