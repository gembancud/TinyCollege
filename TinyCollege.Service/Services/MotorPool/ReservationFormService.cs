using System;
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
    }
}
