﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Service.Services.MotorPool
{
    public class ReservationFormService : BaseService
    {
        public ReservationFormService() : base()
        {
        }

        public IQueryable<ReservationForm> GetReservationForms()
        {
            return _context.ReservationForms;
        }

        public IQueryable<ReservationForm> CreateReservationForm(ReservationForm reservationForm)
        {
            _context.Add(reservationForm);
            _context.SaveChanges();
            return _context.ReservationForms.Where(x => x.ReservationFormId == _context.ReservationForms.Max(x => x.ReservationFormId));
        }

        public IQueryable<Reservation> GetReservationFormReservation(int reservationFormReservationId)
        {
            return _context.Reservations.Where(x => x.ReservationId == reservationFormReservationId);
        }

        public IQueryable<Employee> GetReservationFormEmployee(int reservationFormEmployeeId)
        {
            return _context.Employees.Where(x => x.EmployeeId == reservationFormEmployeeId);
        }
    }
}
