using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Interfaces.IMotorPool
{
    public interface IReport
    {
        int ReportId { get; set; }
        DateTime Month { get; set; }
        string Type { get; set; }

    }
}
