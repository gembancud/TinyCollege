using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
