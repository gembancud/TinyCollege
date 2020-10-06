using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Interfaces.IMotorPool
{
    public interface IEmployee
    {
        int EmployeeId { get; set; }
        string Name { get; set; }
        bool IsMechanic { get; set; }

    }
}
