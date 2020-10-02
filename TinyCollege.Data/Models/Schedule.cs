using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public string Day { get; set; }
        public string RoomCode { get; set; }
        public DateTime Time { get; set; }

        public int SectionId { get; set; }
        public Section Section { get; set; }
    }
}