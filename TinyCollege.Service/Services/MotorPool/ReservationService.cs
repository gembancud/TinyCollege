using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Service.Services.MotorPool
{
    public class ReservationService : BaseService
    {
        public ReservationService() : base()
        {
        }

        public IQueryable<Reservation> GetReservations()
        {
            return _context.Reservations;
        }

        public IQueryable<Reservation> CreateReservation(Reservation reservation)
        {
            _context.Add(reservation);
            _context.SaveChanges();
            return _context.Reservations.Where(x => x.ReservationId == _context.Reservations.Max(x => x.ReservationId));
        }

        public IQueryable<Professor> GetReservationProfessor(int reservationProfessorId)
        {
            return _context.Professors.Where(x => x.ProfessorId == reservationProfessorId);
        }

        public IQueryable<Vehicle> GetReservationVehicle(int reservationVehicleId)
        {
            return _context.Vehicles.Where(x => x.VehicleId == reservationVehicleId);
        }

        public IQueryable<Report> GetReservationReport(int reservationReportId)
        {
            return _context.Reports.Where(x => x.ReportId == reservationReportId);
        }

        public IQueryable<ReservationForm> GetReservationReservationForms(int reservationId)
        {
            return _context.ReservationForms.Where(x => x.ReservationId==reservationId);
        }

        public IQueryable<Reservation> DeleteReservation(Reservation reservation)
        {
            try
            {
                _context.Reservations.Attach(reservation);
                _context.Reservations.Remove(reservation);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // ignored
            }

            return _context.Reservations;
        }
    }
}
