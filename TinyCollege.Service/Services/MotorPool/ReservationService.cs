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

        public List<Reservation> GetReservations()
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Reservations.ToList();
        }

        public List<Reservation> CreateReservation(Reservation reservation)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            _context.Add(reservation);
            _context.SaveChanges();
            return _context.Reservations.Where(x => x.ReservationId == _context.Reservations.Max(x => x.ReservationId)).ToList();
        }

        public List<Professor> GetReservationProfessor(int reservationProfessorId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Professors.Where(x => x.ProfessorId == reservationProfessorId).ToList();
        }

        public List<Vehicle> GetReservationVehicle(int reservationVehicleId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Vehicles.Where(x => x.VehicleId == reservationVehicleId).ToList();
        }

        public List<Report> GetReservationReport(int reservationReportId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Reports.Where(x => x.ReportId == reservationReportId).ToList();
        }

        public List<ReservationForm> GetReservationReservationForms(int reservationId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.ReservationForms.Where(x => x.ReservationId==reservationId).ToList();
        }

        public List<Reservation> DeleteReservation(Reservation reservation)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

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

            return _context.Reservations.ToList();
        }

        public List<Reservation> EditReservation(Reservation reservation)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            var tmpReservation = _context.Reservations.First(x => x.ReservationId == reservation.ReservationId);
            _context.Entry(tmpReservation).CurrentValues.SetValues(reservation);
            _context.SaveChanges();
            return _context.Reservations.Where(x => x.ReservationId == reservation.ReservationId).ToList();
        }
    }
}
