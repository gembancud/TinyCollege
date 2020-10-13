using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TinyCollege.Data.Models;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Service.Services.MotorPool
{
    public class ReservationFormService : BaseService
    {
        public ReservationFormService() : base()
        {
        }

        public List<ReservationForm> GetReservationForms()
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.ReservationForms.ToList();
        }

        public List<ReservationForm> GetReservationForms(string query)
        {
            var stringProperties = typeof(ReservationForm).GetProperties().Where(prop =>
                prop.PropertyType == typeof(string) ||
                prop.PropertyType == typeof(int) ||
                prop.PropertyType == typeof(int?)
            );

            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.ReservationForms.Where(
                delegate (ReservationForm x)
                {
                    return stringProperties.Any(prop => (prop.PropertyType == typeof(int) && prop.GetValue(x)?.ToString() == query) ||
                                                        (prop.PropertyType == typeof(int?) && prop.GetValue(x)?.ToString() == query) ||
                                                        (prop.PropertyType == typeof(string) && EF.Functions.Like(prop.GetValue(x)?.ToString(), $"%{query}%")));
                }
            ).ToList();
        }

        public List<ReservationForm> CreateReservationForm(ReservationForm reservationForm)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            _context.Add(reservationForm);
            _context.SaveChanges();
            return _context.ReservationForms.Where(x => x.ReservationFormId == _context.ReservationForms.Max(x => x.ReservationFormId)).ToList();
        }

        public List<Reservation> GetReservationFormReservation(int reservationFormReservationId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Reservations.Where(x => x.ReservationId == reservationFormReservationId).ToList();
        }

        public List<Employee> GetReservationFormEmployee(int reservationFormEmployeeId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Employees.Where(x => x.EmployeeId == reservationFormEmployeeId).ToList();
        }

        public List<ReservationForm> DeleteReservationForm(ReservationForm reservationForm)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            try
            {
                _context.ReservationForms.Attach(reservationForm);
                _context.ReservationForms.Remove(reservationForm);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // ignored
            }

            return _context.ReservationForms.ToList();
        }

        public List<ReservationForm> EditReservationForm(ReservationForm reservationForm)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            var tmpReservationForm = _context.ReservationForms.First(x => x.ReservationFormId == reservationForm.ReservationFormId);
            _context.Entry(tmpReservationForm).CurrentValues.SetValues(reservationForm);
            _context.SaveChanges();
            return _context.ReservationForms.Where(x => x.ReservationFormId == reservationForm.ReservationFormId).ToList();
        }
    }
}
