using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCollege.Data.Models.MotorPool
{
    public class Part
    {
        public int PartId { get; set; }
        public int CurrentAmount { get; set; }
        public int MinimumLevel { get; set; }

        public ICollection<PartUsage> PartUsages { get; set; }
    }
}