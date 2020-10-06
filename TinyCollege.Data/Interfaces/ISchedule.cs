using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Interfaces
{
    public interface ISchedule
    {
        int ScheduleId { get; set; }
        string Day { get; set; }
        string RoomCode { get; set; }
        DateTime Time { get; set; }

        int? SectionId { get; set; }
    }
}
