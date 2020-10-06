using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Interfaces.IMotorPool
{
    public interface IReservationForm
    {
        int ReservationFormId { get; set; }
        string Type { get; set; }
        string Notes { get; set; }
        DateTime SubmissionDate { get; set; }

        int ReservationId { get; set; }

        int EmployeeId { get; set; }
    }
}
