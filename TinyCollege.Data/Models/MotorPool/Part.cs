using System;
using System.Collections.Generic;
using System.Text;
using TinyCollege.Data.Interfaces.IMotorPool;

namespace TinyCollege.Data.Models.MotorPool
{
    public class Part: IPart
    {
        public int PartId { get; set; }
        public string Name { get; set; }
        public int CurrentAmount { get; set; }
        public int MinimumLevel { get; set; }

        public ICollection<PartUsage> PartUsages { get; set; }
    }
}