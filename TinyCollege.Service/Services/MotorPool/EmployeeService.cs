using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TinyCollege.Data.Models;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Service.Services.MotorPool
{
    public class EmployeeService : BaseService
    {
        public EmployeeService() : base()
        {
        }

        public List<Employee> GetEmployees()
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            return _context.Employees.ToList();
        }

        public List<Employee> GetEmployees(string query)
        {
            var stringProperties = typeof(Employee).GetProperties().Where(prop =>
                prop.PropertyType == typeof(string) ||
                prop.PropertyType == typeof(int) ||
                prop.PropertyType == typeof(int?)
            );

            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Employees.Where(
                delegate (Employee x)
                {
                    return stringProperties.Any(prop => (prop.PropertyType == typeof(int) && prop.GetValue(x)?.ToString() == query) ||
                                                        (prop.PropertyType == typeof(int?) && prop.GetValue(x)?.ToString() == query) ||
                                                        (prop.PropertyType == typeof(string) && EF.Functions.Like(prop.GetValue(x)?.ToString(), $"%{query}%")));
                }
            ).ToList();
        }

        public List<Employee> CreateEmployee(Employee employee)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            _context.Add(employee);
            _context.SaveChanges();
            return _context.Employees.Where(x => x.EmployeeId == _context.Employees.Max(x => x.EmployeeId)).ToList();
        }

        public List<ReservationForm> GetEmployeeReservationForms(int employeeId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.ReservationForms.Where(x => x.EmployeeId == employeeId).ToList();
        }

        public List<MaintenanceDetail> GetEmployeeMaintenanceDetails(int employeeId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.MaintenanceDetails.Where(x => x.EmployeeId == employeeId).ToList();
        }

        public List<Employee> DeleteEmployee(Employee employee)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

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

            return _context.Employees.ToList();
        }

        public List<Employee> EditEmployee(Employee employee)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            var tmpEmployee = _context.Employees.First(x => x.EmployeeId == employee.EmployeeId);
            _context.Entry(tmpEmployee).CurrentValues.SetValues(employee);
            _context.SaveChanges();
            return _context.Employees.Where(x => x.EmployeeId == employee.EmployeeId).ToList();
        }
    }
}
