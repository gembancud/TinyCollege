using System;
using System.Collections.Generic;
using System.Text;
using TinyCollege.Data.Interfaces.IMotorPool;

namespace TinyCollege.Data.Models.MotorPool
{
    public class Employee : IEmployee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public bool IsMechanic { get; set; }

        public ICollection<ReservationForm> Forms { get; set; }
    }
}