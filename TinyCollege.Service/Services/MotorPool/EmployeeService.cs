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
            return _context.Employees.Where(x => x.EmployeeId == _context.Employees.Max(x => x.EmployeeId));
        }

        public IQueryable<ReservationForm> GetEmployeeReservationForms(int employeeId)
        {
            return _context.ReservationForms.Where(x => x.EmployeeId == employeeId);
        }

        public IQueryable<MaintenanceDetail> GetEmployeeMaintenanceDetails(int employeeId)
        {
            return _context.MaintenanceDetails.Where(x => x.EmployeeId == employeeId);
        }

        public IQueryable<Employee> DeleteEmployee(Employee employee)
        {
            try
            {
                _context.Employees.Attach(employee);
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // ignored
            }

            return _context.Employees;
        }
    }
}
