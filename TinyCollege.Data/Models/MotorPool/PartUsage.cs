using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Models.MotorPool
{
    public class PartUsage
    {
        public int PartUsageId { get; set; }
        public int Count { get; set; }

        public int PartId { get; set; }
        public Part Part { get; set; }

        public int FormId { get; set; }
        public Form Form { get; set; }
    }
}